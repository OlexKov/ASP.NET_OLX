using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_OLX.Controllers.ControllerInerfaces
{
	public interface IAdvertDelete
	{
		Task<IActionResult> DeleteElement(int id, [FromServices] IWebHostEnvironment env, [FromServices] IConfiguration config);
	}
}
