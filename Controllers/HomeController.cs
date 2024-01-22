using ASP.NET_OLX.Models;
using ASP.NET_OLX.Models.Data;
using ASP.NET_OLX.Models.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;

namespace ASP.NET_OLX.Controllers
{
    public class HomeController : Controller
    {
        private readonly OlxDBContext context;
        private readonly IIncludableQueryable<Advert, ICollection<Image>> adverts;

        public HomeController(OlxDBContext context)
        {
            this.context = context;
            adverts = context.Adverts.Include(x => x.Category).Include(x => x.City).Include(x => x.Images);
        }

        public async Task<IActionResult> Index() => View(await adverts.ToArrayAsync());

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
