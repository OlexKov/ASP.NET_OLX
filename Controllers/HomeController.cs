using ASP.NET_OLX.Models;
using ASP.NET_OLX.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.NET_OLX.Controllers
{
    public class HomeController(OlxDBContext context) : Controller
    {
       private readonly OlxDBContext context = context;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
