using ApplicationCore.DTOs;
using ApplicationCore.Models;
using ApplicationCore.Services.Interfaces;
using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;

namespace ASP.NET_OLX.Controllers
{
	public class BaseController : Controller
	{
		protected readonly IAdvertService advertService;
       
        public virtual async Task<IActionResult> Index() => View(await advertService.GetAllAdverts());
		
		public BaseController(IAdvertService advertService) {this.advertService = advertService;}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
