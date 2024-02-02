using ApplicationCore.Services.Interfaces;
using ASP.NET_OLX.Services;
using ASP.NET_OLX.Services.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_OLX.Controllers
{
	public class FavouriteController : BaseController
	{
        private readonly IFavouriteService favouriteService;

        public FavouriteController(IAdvertService advertService, IFavouriteService favouriteService) : base(advertService)
        {
            this.favouriteService = favouriteService;
        }

        public async Task<IActionResult> Index() => View(await favouriteService.GetFavouriteAdverts());

        public int Add(int id)
        {
            favouriteService.Add(id);
            return favouriteService.GetCount();
        }

        public int Remove(int id)
        {
            favouriteService.Remove(id);
            return favouriteService.GetCount();
        }
    }
}
