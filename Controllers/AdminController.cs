using ASP.NET_OLX.Models;
using ASP.NET_OLX.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ASP.NET_OLX.Controllers
{
    public class AdminController(OlxDBContext context) : Controller
    {
        private readonly OlxDBContext context = context;
        public IActionResult Index()
        {
            context.Images.Load();
            var data = context.SaleAdvertisements.Include(x => x.Category)
                                                   .Include(x => x.City)
                                                   .Include(x => x.SaleAdvertisementsImages).ToArray();
            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
