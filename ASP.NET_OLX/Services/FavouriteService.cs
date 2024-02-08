using ApplicationCore.DTOs;
using ApplicationCore.Services.Interfaces;
using ASP.NET_OLX.Expressions;
using ASP.NET_OLX.Services.Interfaces;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_OLX.Services
{
    public class FavouriteService : IFavouriteService
	{
		private readonly string fauvorite_key = "fauvorite_adverts_key";
		private readonly HttpContext httpContext;
		private readonly IAdvertService advertService;
        private readonly UserManager<User> userManager;
        private readonly OlxDBContext dbContext;
		private readonly User? currentUser;


        public FavouriteService(IHttpContextAccessor httpContextAccessor, OlxDBContext context, UserManager<User> userManager, IAdvertService advertService)
		{
			this.dbContext = context;
            this.userManager = userManager;
            this.advertService = advertService;
			httpContext = httpContextAccessor.HttpContext!;
            if (httpContext.User?.Identity?.IsAuthenticated ?? false)
                currentUser = userManager.GetUserAsync(httpContext.User).Result;

        }

        private void SaveItems(IEnumerable<int> items) => httpContext.Session.Set(fauvorite_key, items);

		private async Task<List<int>?> GetItems()
		{
            var user = currentUser;
			return user == null ? httpContext.Session.Get<List<int>>(fauvorite_key)
			                    :await dbContext.UserFavouriteAdverts.Where(x => x.UserId == user.Id)
                                                    .Select(x => x.AdvertId)
                                                    .ToListAsync();
        }

		public async Task<int> GetCount()
		{
            var user = currentUser;
			return user == null ? (await GetItems())?.Count ?? 0
								: await dbContext.UserFavouriteAdverts.Where(x => x.UserId == user.Id).CountAsync();
        }

		public async Task Add(int id)
		{
			var user = currentUser;
            if (user == null)
			{
				var ids = await GetItems();
				ids ??= [];
				ids.Add(id);
				SaveItems(ids);
			}
			else 
			{
				await dbContext.UserFavouriteAdverts.AddAsync(new() {UserId = user.Id,AdvertId = id });
				await dbContext.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<AdvertDto>> GetFavouriteAdverts()
		{
			var ids = await GetItems() ?? [];
			return await advertService.GetAdverts(ids);
        }

		public async Task Remove(int id)
		{
            var user = currentUser;
			if (user == null)
			{
				var ids = await GetItems();
				if (ids == null) return;
				ids.Remove(id);
				SaveItems(ids);
			}
			else 
			{
				var toDelete = await dbContext.UserFavouriteAdverts.FirstOrDefaultAsync(x=>x.UserId == user.Id && x.AdvertId == id);
                dbContext.UserFavouriteAdverts.Remove(toDelete);
				await dbContext.SaveChangesAsync();
            }
		}
		public async Task<bool> IsFavourite(int id) =>(await GetItems())?.Contains(id) ?? false;
    }
}
