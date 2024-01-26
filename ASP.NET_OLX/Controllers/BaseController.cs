using ASP.NET_OLX.Models;
using ASP.NET_OLX_DATABASE;
using ASP.NET_OLX_DATABASE.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;

namespace ASP.NET_OLX.Controllers
{
    public class BaseController : Controller
	{
		protected readonly OlxDBContext context;
		protected readonly IIncludableQueryable<Advert, ICollection<Image>> adverts;

		public virtual async Task<IActionResult> Index()
		{
			return View(await adverts.ToArrayAsync());
		}


		public BaseController(OlxDBContext context)
        {
			this.context = context;
			adverts = context.Adverts.Include(x => x.Category).Include(x => x.City).Include(x => x.Images);
		}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
