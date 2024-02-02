using ApplicationCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ASP.NET_OLX.Controllers
{
    public class HomeController :BaseController
	{
		
		public HomeController(IAdvertService advertService) :base(advertService) {}

		public async Task<IActionResult> Index()
		{
			ViewBag.Cities = await advertService.GetAllCities();
			ViewBag.Categories = await advertService.GetAllCategories();
			return View(await advertService.GetAllAdverts());
		}

		public async Task<IActionResult> AdvertPartial(string partial,string sort,string category,string state,decimal from,decimal to,string? find ,string fcity)
		{
			return PartialView(partial,await advertService.AdvertFilter(sort,category,state,from,to,find,fcity));
		}

		public async Task<IActionResult> ShowAdvert(int id, [FromServices] IConfiguration config)
		{
			var advert = await advertService.GetAdvert(id);
            ViewBag.Images = (await advertService.GetAdvertImages(id)).ToArray();
            return View(advert);
		}

    }
}
