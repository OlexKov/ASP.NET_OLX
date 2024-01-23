using ASP.NET_OLX.Models;
using ASP.NET_OLX_DATABASE;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace ASP.NET_OLX.Controllers
{
    public class AdminController: Controller
    {
        private readonly OlxDBContext context;
       
        public AdminController(OlxDBContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index() => View(await context.Adverts
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

        public async Task<IActionResult> DeleteElement(int id, [FromServices] IWebHostEnvironment env, [FromServices] IConfiguration config)
        {
            var images = context.Images.Where(x => x.AdvertId == id);
            foreach (var image in images)
                System.IO.File.Delete(Path.Combine(env.WebRootPath, config["UserImgDir"] ?? string.Empty, Path.GetFileName(image.Url)));
            var  advert = await context.Adverts.FindAsync(id) ?? new();
            context.Images.RemoveRange(images);
            context.Adverts.Remove(advert);
            await  context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
