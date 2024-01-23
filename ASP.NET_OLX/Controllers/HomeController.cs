using ASP.NET_OLX.Models;
using ASP.NET_OLX_DATABASE;
using ASP.NET_OLX_DATABASE.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;

namespace ASP.NET_OLX.Controllers
{
    public class HomeController : AdvertShowController
	{
        public HomeController(OlxDBContext context):base(context){}

        public override async Task<IActionResult> Index() => await base.Index();
       
    }
}
