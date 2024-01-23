using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_OLX.Controllers.ControllerInerfaces
{
	public interface IAdvertShow
	{
		Task<IActionResult> ShowAdvert(int id);
	}
}
