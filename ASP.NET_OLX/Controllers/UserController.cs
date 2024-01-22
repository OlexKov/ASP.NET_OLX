using ASP.NET_OLX.Models;
using ASP.NET_OLX_DATABASE;
using ASP.NET_OLX_DATABASE.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;

namespace ASP.NET_OLX.Controllers
{
    public class UserController : Controller
    {
        private readonly OlxDBContext context;
        private readonly IWebHostEnvironment environment;
        private readonly IConfiguration configuration;
        private List<string> imageToDelete = [];

        private readonly IIncludableQueryable<Advert, ICollection<Image>> adverts;

        private async Task<string> saveImage(IFormFile file, IWebHostEnvironment env)
        {
            string fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(env.WebRootPath, configuration["UserImgDir"], fileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            var location = new Uri($"{Request.Scheme}://{Request.Host}/{configuration["UserImgDir"]}/{fileName}");
            return location.AbsoluteUri;
        }

        public UserController(OlxDBContext context, IWebHostEnvironment env, IConfiguration config)
        {
            this.configuration = config;
            this.environment = env;
            this.context = context;
            adverts = context.Adverts.Include(x => x.Category).Include(x => x.City).Include(x => x.Images);
        }

               
        public async Task RemoveImage(string url)
        {
            var deleteImage = await context.Images.FirstOrDefaultAsync(x=>x.Url == url);
            context.Images.Remove(deleteImage);
            await context.SaveChangesAsync();
            System.IO.File.Delete(Path.Combine(environment.WebRootPath, configuration["UserImgDir"], Path.GetFileName(url)));
        }

        public async Task<IActionResult> AddAdvert(int id)
        {
            var advertModel = new AdvertModel();
            if (id != 0)
            {
                var advert = await adverts.FirstOrDefaultAsync(x => x.Id == id);
                advertModel.Id = advert.Id;
                advertModel.SellerName = advert.SellerName;
                advertModel.City = advert.City.Name;
                advertModel.Category = advert.Category.Name;
                advertModel.Title = advert.Title;
                advertModel.Description = advert.Description;
                advertModel.IsNew = advert.IsNew;
                advertModel.Price = advert.Price;
                foreach (var item in advert.Images)
                     advertModel.ImagesUrls.Add(item.Url);
            }
            ViewBag.Categories = await context.Categories.Select(x => x.Name).ToArrayAsync();
            ViewBag.Cities = await context.Cities.Select(x => x.Name).ToArrayAsync();
            return View("AddAdvert", advertModel);
        }

        public async Task<IActionResult> PersonalAccount()
        {
            return View(await adverts.ToArrayAsync());
        }
   
        [HttpPost]
        public async Task<IActionResult> Create(AdvertModel advertModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await context.Categories.Select(x => x.Name).ToArrayAsync();
                ViewBag.Cities = await context.Cities.Select(x => x.Name).ToArrayAsync();
                return View("AddAdvert", advertModel);
            }
            Advert advert = null;
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Name == advertModel.Category);

            var city = await context.Cities.FirstOrDefaultAsync(x => x.Name == advertModel.City);
            if (advertModel.Id != 0)
            {
                advert = await adverts.FirstOrDefaultAsync(x=>x.Id == advertModel.Id);
                advert.Description = advertModel.Description;
                advert.SellerName = advertModel.SellerName;
                advert.IsNew = advertModel.IsNew;
                advert.CategoryId = category.Id;
                advert.CityId = city.Id;
                 advert.Price = advertModel.Price;
                advert.Title = advertModel.Title;
            }
            else
            {
                advert = new Advert
                {
                    Date = DateTime.Now,
                    Description = advertModel.Description,
                    SellerName = advertModel.SellerName,
                    IsNew = advertModel.IsNew,
                    CategoryId = category.Id,
                    CityId = city.Id,
                    Price = advertModel.Price,
                    Title = advertModel.Title
                };
            }
            foreach (var item in advertModel.Images)
                advert.Images.Add(new Image() { Url = await saveImage(item, environment) });
            if(advertModel.Id == 0)
                await context.Adverts.AddAsync(advert);
            await context.SaveChangesAsync();
            return RedirectToAction("PersonalAccount");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
