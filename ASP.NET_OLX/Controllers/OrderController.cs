using ApplicationCore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_OLX.Controllers
{
	[Authorize(Roles = "User")]
	public class OrderController : BaseController
	{
		public OrderController(IAdvertService advertService) : base(advertService){}

		public async Task<IActionResult> Index() => View();

		public async Task<IActionResult> Order(int advertId) => View();
	}
}
