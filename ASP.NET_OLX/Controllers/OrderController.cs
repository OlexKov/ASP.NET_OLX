using ApplicationCore.DTOs;
using ApplicationCore.Services.Interfaces;
using AutoMapper;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASP.NET_OLX.Controllers
{
	[Authorize(Roles = "User")]
	public class OrderController : Controller
	{
		private readonly IOrderService orderService;
		private readonly UserManager<User> userManager;
		private readonly IAdvertService advertService;

		private async Task setViewBag() => ViewBag.Cities = new SelectList(await advertService.GetAllCities(), nameof(City.Id), nameof(City.Name));

		public OrderController(IOrderService orderService, UserManager<User> userManager,IAdvertService advertService)
		{
			this.orderService = orderService;
			this.userManager = userManager;
			this.advertService = advertService;
		}

		public async Task<IActionResult> Index() => View(await orderService.GetUserOrders(User));

		public async Task<IActionResult> Order(int id)
		{
			await setViewBag();
			var orderDto = new OrderDto() 
			{
				UserId = (await userManager.GetUserAsync(User)).Id, 
				AdvertId = id,
				OrderDate = DateTime.Now 
			};
			return View(orderDto);
		}
		

		[HttpPost]
		public async Task<IActionResult> AddOrder(OrderDto orderDto)
		{
			if (!ModelState.IsValid)
			{
				await setViewBag();
				return View("Order", orderDto);
			}

			await orderService.CreateOrder(orderDto);
			return RedirectToAction("Index"); ;
		}
	}
}
