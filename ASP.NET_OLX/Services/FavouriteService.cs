using ApplicationCore.DTOs;
using ApplicationCore.Services.Interfaces;
using ASP.NET_OLX.Expressions;
using ASP.NET_OLX.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace ASP.NET_OLX.Services
{
	public class FavouriteService : IFavouriteService
	{
		private readonly string fauvorite_key = "fauvorite_adverts_key";
		private readonly HttpContext httpContext;
		private readonly IAdvertService advertService;

		public FavouriteService(IHttpContextAccessor httpContextAccessor, IAdvertService advertService)
		{
			this.advertService = advertService;
			httpContext = httpContextAccessor.HttpContext!;
		}

		private void SaveItems(IEnumerable<int> items) =>  httpContext.Session.Set(fauvorite_key, items);

		private List<int>? GetItems() => httpContext.Session.Get<List<int>>(fauvorite_key);

		public int GetCount() => GetItems()?.Count ?? 0;

		public void Add(int id)
		{
			var ids = GetItems();
			ids ??= [];
			ids.Add(id);
			SaveItems(ids);
		}

		public async Task<IEnumerable<AdvertDto>> GetFavouriteAdverts()
		{
			IEnumerable<int> ids = GetItems() ?? Enumerable.Empty<int>();
			return await advertService.GetAdverts(ids);
		}

		public void Remove(int id)
		{
			var ids = GetItems();
			if (ids == null) return;
			ids.Remove(id);
			SaveItems(ids);
		}

		public bool IsFavourite(int id) => GetItems()?.Contains(id) ?? false;

    }
}
