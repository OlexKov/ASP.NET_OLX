using ASP.NET_OLX.Controllers.ControllerInerfaces;
using ASP.NET_OLX_DATABASE;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_OLX.Controllers
{
	public class AdvertShowController : BaseController, IAdvertShow
	{
        public AdvertShowController(OlxDBContext context) : base(context){}

        public async Task<IActionResult> ShowAdvert(int id) => View(await adverts.FirstOrDefaultAsync(x => x.Id == id));
    }
}
