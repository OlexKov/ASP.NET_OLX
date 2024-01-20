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
        private readonly IIncludableQueryable<Advert, ICollection<AdvertImage>> adverts;
        public AdminController(OlxDBContext context)
        {
            Console.WriteLine("Admin controller");
            this.context = context;
            adverts = context.Adverts.Include(x => x.Category).Include(x => x.City).Include(x => x.AdvertImages);
        }

        public async Task<IActionResult> Index()
        {
            Console.WriteLine("Admin Index");
            await context.Images.LoadAsync();
            return View(adverts.ToArray());
        }
     
        public IActionResult ShowPartialView(int id)
        {
            Console.WriteLine("Admin PartialView");
            context.AdvertImages.Where(x=>x.AdvertId == id).Include(x=>x.Image).ToArray();
            var element = adverts.FirstOrDefault(x=>x.Id == id);
            return PartialView("_ShowPartialView", element);
        }

        public async Task<IActionResult> DeleteElement(int id, [FromServices] IWebHostEnvironment env)
        {
            Console.WriteLine("Admin DeleteElement");
            var toDelete = context.AdvertImages.Where(x => x.AdvertId == id).Select(x=>x.ImageId).ToArray();
            var fileNames = context.Images.Where(x => toDelete.Any(y => y == x.Id)).Select(x=>Path.GetFileName(x.Url));
            foreach (var fName in fileNames)
                System.IO.File.Delete(Path.Combine(env.WebRootPath, imageDirPath, fName));
            foreach (var itemId in toDelete)
                   context.Images.Remove(context.Images.Find(itemId));
            var item =  context.Adverts.Find(id);
            context.Adverts.Remove(item);
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
