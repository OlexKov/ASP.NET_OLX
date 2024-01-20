using ASP.NET_OLX.Models;
using ASP.NET_OLX.Models.Data;
using ASP.NET_OLX.Models.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Diagnostics;


namespace ASP.NET_OLX.Controllers
{
    public class AdminController: Controller
    {
        private readonly OlxDBContext context;
        private const string imageDirPath = "UsersAdvertsImages";
        private readonly IIncludableQueryable<Advert, ICollection<Image>> adverts;
        public AdminController(OlxDBContext context)
        {
            this.context = context;
            adverts = context.Adverts.Include(x => x.Category).Include(x => x.City).Include(x => x.Images);
        }

        public async Task<IActionResult> Index()
        {
           // await context.Images.LoadAsync();
            return View(await adverts.ToArrayAsync());
        }
     
        public async Task<IActionResult> ShowPartialView(int id)
        {
            var element = await adverts.FirstOrDefaultAsync(x=>x.Id == id);
            return PartialView("_ShowPartialView", element);
        }

        public async Task<IActionResult> DeleteElement(int id, [FromServices] IWebHostEnvironment env)
        {
           
            var fileNames = context.Images.Where(x => x.AdvertId == id).Select(x=>Path.GetFileName(x.Url));
            foreach (var fName in fileNames)
                System.IO.File.Delete(Path.Combine(env.WebRootPath, imageDirPath, fName));
            var advert = context.Adverts.Find(id);
            foreach (var image in advert.Images)
                context.Images.Remove(image);
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
