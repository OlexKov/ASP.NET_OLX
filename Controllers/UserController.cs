using ASP.NET_OLX.Models;
using ASP.NET_OLX.Models.Data;
using ASP.NET_OLX.Models.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace ASP.NET_OLX.Controllers
{
    public class UserController(OlxDBContext context) : Controller
    {
        private readonly OlxDBContext context = context;

        public IActionResult Index()
        {
            context.Images.Load();
            var data = context.SaleAdvertisements.Include(x=>x.Category)
                                                   .Include(x=>x.City)
                                                   .Include(x=>x.SaleAdvertisementsImages).ToArray();
            return View(data);
        }

        public IActionResult AddAdvertisement()
        {
             ViewBag.Categories = context.Categories.Select(x => x.Name).ToArray();
             ViewBag.Cities = context.Cities.Select(x => x.Name).ToArray();
             return View();
        }

        [HttpPost]
        public IActionResult Create(AdvertisementCreationModel saleAdvertisement)
        {
            
            var newAdvertisement = new SaleAdvertisement
            {
                Date = DateTime.Now,
                Description = saleAdvertisement.Description,
                SellerName = saleAdvertisement.SellerName,
                IsNew = saleAdvertisement.IsNew,
                CategoryId = context.Categories.FirstOrDefault(x => x.Name == saleAdvertisement.Category).Id,
                CityId = context.Cities.FirstOrDefault(x => x.Name == saleAdvertisement.City).Id,
                Price = saleAdvertisement.Price,
                Title = saleAdvertisement.Title
            };
            var img = context.Images.FirstOrDefault(x => x.Url == saleAdvertisement.ImagesUrl);
            if (img != null)
                context.SaleAdvertisementsImages.Add(new SaleAdvertisementImage() { ImageId = img.Id, SaleAdvertisement = newAdvertisement });
            else 
                context.SaleAdvertisementsImages.Add(new SaleAdvertisementImage() {Image = new() {Url = saleAdvertisement.ImagesUrl },SaleAdvertisement = newAdvertisement });
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
