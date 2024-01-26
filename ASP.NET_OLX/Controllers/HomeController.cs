using ASP.NET_OLX_DATABASE;
using ASP.NET_OLX_DATABASE.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ASP.NET_OLX.Controllers
{
	public class HomeController :Controller
	{
		protected readonly OlxDBContext context;
		protected readonly IIncludableQueryable<Advert, ICollection<Image>> adverts;

		public HomeController(OlxDBContext context)
		{
			this.context = context;
			adverts = context.Adverts.Include(x => x.Category).Include(x => x.City).Include(x => x.Images);
		}

        public async Task<IActionResult> Index(string partial) 
        {
            if (partial == null) ViewBag.Partial = "_ShowAdvertsPartial";
            else ViewBag.Partial = partial;
			return View(await adverts.ToArrayAsync());
		}

        public async Task<IActionResult> ShowAdvert(int id) => View(await adverts.FirstOrDefaultAsync(x => x.Id == id));

    }
}
