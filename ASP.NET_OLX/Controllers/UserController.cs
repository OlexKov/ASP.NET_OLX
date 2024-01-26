using ASP.NET_OLX.Models;
using ASP.NET_OLX.Services;
using ASP.NET_OLX_DATABASE;
using ASP.NET_OLX_DATABASE.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;

namespace ASP.NET_OLX.Controllers
{
    public class UserController : BaseController
	{
        private readonly IWebHostEnvironment environment;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        [NonAction]
		private  void setDataToBag()
        {
            ViewBag.Categories = new SelectList(context.Categories.ToList(), nameof(Category.Id), nameof(Category.Name));
            ViewBag.Cities = new SelectList(context.Cities.ToList(), nameof(City.Id), nameof(City.Name));
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

        public UserController(OlxDBContext context, IWebHostEnvironment env, IConfiguration config, IMapper mapper) :base(context)
        {
            this.mapper = mapper;
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
            setDataToBag();
            if (id != 0)
            {
                var advert = await adverts.FirstOrDefaultAsync(x => x.Id == id);
                if (advert == null) return NotFound();
                AdvertModel advertModel = mapper.Map<AdvertModel>(advert);
                advertModel.ImagesUrls = advert.Images.Select(x=>x.Url).ToList();
                return View(advertModel);
            }
			return View();
        }

		public override async Task<IActionResult> Index() => await base.Index();

		[HttpPost]
        public async Task<IActionResult> Create(AdvertModel advertModel)
        {
            Advert? advert;
            
            if (!ModelState.IsValid)
            {
                setDataToBag();
				return View("AddAdvert", advertModel);
            }
              
            if (advertModel.Id != 0)
                advert = mapper.Map<Advert>(advertModel);
            else
            {
                advert = mapper.Map<Advert>(advertModel);
                advert.Date = DateTime.Now;
            }

            foreach (var item in advertModel.ImageFiles)
                advert.Images.Add(new Image() { Url = await saveImage(item) });

            if(advertModel.Id == 0)
                await context.Adverts.AddAsync(advert);
            else
                context.Adverts.Update(advert);

            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
