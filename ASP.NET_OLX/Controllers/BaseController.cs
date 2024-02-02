using ApplicationCore.Models;
using ApplicationCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.NET_OLX.Controllers
{
    public abstract class BaseController : Controller
	{
		protected readonly IAdvertService advertService;
       
        public BaseController(IAdvertService advertService) {this.advertService = advertService;}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
