using ASP.NET_OLX.Models;
using ASP.NET_OLX.Services;
using ASP.NET_OLX_DATABASE;
using ASP.NET_OLX_DATABASE.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;

namespace ASP.NET_OLX.Controllers
{
    public class UserController : BaseController
	{
        private readonly IWebHostEnvironment environment;
        private readonly IConfiguration configuration;

		[NonAction]
		private async Task setDataToBag()
        {
			ViewBag.Categories = await context.Categories.Select(x => x.Name).ToArrayAsync();
			ViewBag.Cities = await context.Cities.Select(x => x.Name).ToArrayAsync();
		}

		[NonAction]
		private async Task<string> saveImage(IFormFile file)
        {
            string fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(environment.WebRootPath, configuration["UserImgDir"] ?? string.Empty, fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            var imageUrl = new Uri($"{Request.Scheme}://{Request.Host}/{configuration["UserImgDir"]}/{fileName}");
            return imageUrl.AbsoluteUri;
        }

        public UserController(OlxDBContext context, IWebHostEnvironment env, IConfiguration config):base(context)
        {
            this.configuration = config;
            this.environment = env;
        }

		
		public async Task RemoveImage(string url)
        {
            var deleteImage = await context.Images.FirstOrDefaultAsync(x=>x.Url == url) ?? new();
            context.Images.Remove(deleteImage);
            await context.SaveChangesAsync();
            System.IO.File.Delete(Path.Combine(environment.WebRootPath, configuration["UserImgDir"] ?? string.Empty, Path.GetFileName(url)));
        }

        public async Task<IActionResult> ShowAdvert(int id) => View(await adverts.FirstOrDefaultAsync(x => x.Id == id));

        public async Task<IActionResult> DeleteElement(int id, [FromServices] AdvertRemover remover, [FromServices] IWebHostEnvironment env, [FromServices] IConfiguration config)
        {
            await remover.RemoveAdvert(id, context,env,config);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddAdvert(int id)
        {
            var advertModel = new AdvertModel();
            if (id != 0)
            {
                var advert = await adverts.FirstOrDefaultAsync(x => x.Id == id) ?? new();
                advertModel.Id = advert.Id;
                advertModel.SellerName = advert.SellerName;
                advertModel.City = advert.City.Name;
                advertModel.Category = advert.Category.Name;
                advertModel.Title = advert.Title;
                advertModel.Description = advert.Description;
                advertModel.IsNew = advert.IsNew;
                advertModel.Price = advert.Price;
                advertModel.ImagesUrls = advert.Images.Select(x=>x.Url).ToList();
            }
			await setDataToBag();
			return View("AddAdvert", advertModel);
        }

		public override async Task<IActionResult> Index() => await base.Index();

		[HttpPost]
        public async Task<IActionResult> Create(AdvertModel advertModel)
        {
            if (!ModelState.IsValid)
            {
                await setDataToBag();
				return View("AddAdvert", advertModel);
            }
            Advert advert;
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Name == advertModel.Category) ?? new();
            var city = await context.Cities.FirstOrDefaultAsync(x => x.Name == advertModel.City) ?? new();
            if (advertModel.Id != 0)
            {
                advert = await adverts.FirstOrDefaultAsync(x=>x.Id == advertModel.Id) ?? new();
                advert.Description = advertModel.Description ?? string.Empty;
                advert.SellerName = advertModel.SellerName ?? string.Empty;
				advert.IsNew = advertModel.IsNew;
                advert.CategoryId = category.Id;
                advert.CityId = city.Id;
                advert.Price = advertModel.Price;
                advert.Title = advertModel.Title ?? string.Empty;
            }
            else
            {
                advert = new Advert
                {
                    Date = DateTime.Now,
                    Description = advertModel.Description ?? string.Empty,
                    SellerName = advertModel.SellerName ?? string.Empty,
                    IsNew = advertModel.IsNew,
                    CategoryId = category.Id,
                    CityId = city.Id,
                    Price = advertModel.Price,
                    Title = advertModel.Title ?? string.Empty
				};
            }
            foreach (var item in advertModel.Images)
                advert.Images.Add(new Image() { Url = await saveImage(item) });
            if(advertModel.Id == 0)
                await context.Adverts.AddAsync(advert);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
      
    }
}
