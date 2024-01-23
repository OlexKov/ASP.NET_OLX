using ASP.NET_OLX.Models;
using ASP.NET_OLX.Services;
using ASP.NET_OLX_DATABASE;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace ASP.NET_OLX.Controllers
{
    public class AdminController : BaseController
	{
        public AdminController(OlxDBContext context):base(context){}

        public override async Task<IActionResult> Index() => View(await context.Adverts
            .Include(x => x.Category)
            .Include(x => x.City).ToArrayAsync());
            
        public async Task<IActionResult> ShowPartialView(int id)
        {
			return PartialView("_ShowPartialView", await context.Adverts
                .Include(x => x.Category)
                .Include(x => x.City)
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x=>x.Id == id));
        }

        public async Task<IActionResult> DeleteElement(int id, [FromServices] AdvertRemover remover)
        {
            await remover.RemoveAdvert(id, context);
            return RedirectToAction("Index");
        }
    }
}
