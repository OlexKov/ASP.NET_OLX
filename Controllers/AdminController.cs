using ASP.NET_OLX.Models;
using ASP.NET_OLX.Models.Data;
using ASP.NET_OLX.Models.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace ASP.NET_OLX.Controllers
{
    public class AdminController: Controller
    {


        private readonly OlxDBContext context;
        private readonly IIncludableQueryable<SaleAd, ICollection<SaleAdImage>> saleAd; 

        public AdminController(OlxDBContext context)
        {
            this.context = context;
            context.Images.Load();
            saleAd = context.SaleAds.Include(x => x.Category)
                                                   .Include(x => x.City)
                                                   .Include(x => x.SaleAdImages);
        }
        public IActionResult Index() => View(saleAd.ToArray());
        

        public IActionResult ShowPartialView(int id)
        {
            var element = saleAd.Include(x => x.Category).FirstOrDefault(x=>x.Id==id);
            return PartialView("_ShowPartialView", element);
        }

        public  IActionResult DeleteElement(int id)
        {
            var toDelete = context.SaleAdImages.Where(x => x.SaleAdId == id).Select(x=>x.ImageId).ToArray();
            foreach (var itemId in toDelete)
                   context.Images.Remove(context.Images.Find(itemId));
            var item =  context.SaleAds.Find(id);
            context.SaleAds.Remove(item);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
