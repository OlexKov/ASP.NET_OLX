using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ASP.NET_OLX.Controllers
{
	public class HomeController :BaseController
	{
		private bool advertsFilter(Advert advert,string category)
		{
			if (category == "Всі категорії") return true;
			return advert.Category.Name == category;
		}

		public HomeController(OlxDBContext context):base(context){}

		public override async Task<IActionResult> Index()
		{
			ViewBag.Cities = await context.Cities.ToArrayAsync();
			ViewBag.Categories = await context.Categories.ToArrayAsync();
			return View(await adverts.ToArrayAsync());
		}

		public async Task<IActionResult> AdvertPartial(string partial,string sort,string category)
		{
			var filteredAdverts = adverts.ToArray().Where(x => advertsFilter(x, category)).ToArray();
			var sortedAdverts = sort == null
				 ? filteredAdverts
				 : sort == "date"
				 ? filteredAdverts.OrderBy(x => x.Date).ToArray()
				 : filteredAdverts.OrderBy(x => x.Title).ToArray();
			return PartialView(partial,  sortedAdverts);
		}

        public async Task<IActionResult> ShowAdvert(int id) => View(await adverts.FirstOrDefaultAsync(x => x.Id == id));

    }
}
