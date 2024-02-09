using ApplicationCore.Services.Interfaces;
using ASP.NET_OLX.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_OLX.Controllers
{
	[Authorize(Roles = "User")]
	public class FavouriteController : BaseController
	{
        private readonly IFavouriteService favouriteService;

        public FavouriteController(IAdvertService advertService, IFavouriteService favouriteService) : base(advertService)
        {
            this.favouriteService = favouriteService;
        }

        public async Task<IActionResult> Index() => View(await favouriteService.GetFavouriteAdverts());

        public async Task<IActionResult> ShowAdvert(int id)
        {
            var advert = await advertService.GetAdvert(id);
            ViewBag.Images = (await advertService.GetAdvertImages(id)).ToArray();
            return View(advert);
        }

        public async Task<int> Add(int id)
        {
            await favouriteService.Add(id);
            return await favouriteService.GetCount();
        }

        public async Task<int> Remove(int id)
        {
            await favouriteService.Remove(id);
            return await favouriteService.GetCount();
        }
    }
}
