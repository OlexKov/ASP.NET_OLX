using ASP.NET_OLX.Models;
using ASP.NET_OLX.Models.Data;
using ASP.NET_OLX.Models.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;

namespace ASP.NET_OLX.Controllers
{
    public class UserController : Controller
    {
        private readonly OlxDBContext context;

        private const string imageDirPath = "UsersAdvertsImages";

        private readonly IIncludableQueryable<Advert, ICollection<AdvertImage>> adverts;

        private async Task<string> saveImage(IFormFile file,IWebHostEnvironment env)
        {
            string fileName  = Guid.NewGuid().ToString("N")+Path.GetExtension(file.FileName);
            string filePath = Path.Combine(env.WebRootPath, imageDirPath, fileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
               await  file.CopyToAsync(fileStream);
            }
            var location = new Uri($"{Request.Scheme}://{Request.Host}/{imageDirPath}/{fileName}");
            return location.AbsoluteUri;
        }

        public UserController(OlxDBContext context)
        {
            Console.WriteLine("User controller");
            this.context = context;
            adverts = context.Adverts.Include(x => x.Category).Include(x => x.City).Include(x => x.AdvertImages);
        }

        public async Task<IActionResult> Index()
        {
            Console.WriteLine("User Index");
            await context.Images.LoadAsync();
            var data = adverts.ToArray();
            return View(data);
        }

        public IActionResult AddAdvert()
        {
            Console.WriteLine("User AddAdvert");
            ViewBag.Categories = context.Categories.Select(x => x.Name).ToArray();
            ViewBag.Cities = context.Cities.Select(x => x.Name).ToArray();
            return View();
        }

        public IActionResult PersonalAccount()
        {
            Console.WriteLine("User PersonalAccount");
            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> Create(AdvertCreationModel saleAd, [FromServices] IWebHostEnvironment env)
        {
            var newAd = new Advert
            {
                Date = DateTime.Now,
                Description = saleAd.Description,
                SellerName = saleAd.SellerName,
                IsNew = saleAd.IsNew,
                CategoryId = context.Categories.FirstOrDefault(x => x.Name == saleAd.Category).Id,
                CityId = context.Cities.FirstOrDefault(x => x.Name == saleAd.City).Id,
                Price = saleAd.Price,
                Title = saleAd.Title
            };

            foreach (var item in saleAd.Images)
                  context.AdvertImages.Add(new AdvertImage () { Image = new() { Url = await saveImage(item,env) }, Advert = newAd });
            
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
