using ApplicationCore.DTOs;
using ApplicationCore.Models;
using ApplicationCore.Services;
using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_OLX.Controllers
{
	public class UserController : BaseController
	{
        private readonly IWebHostEnvironment environment;
        private readonly IConfiguration configuration;

        [NonAction]
		private async Task setDataToBag()
        {
            ViewBag.Categories = new SelectList(mapper.Map<CategoryDto[]> (await context.Categories.ToListAsync()), nameof(CategoryDto.Id), nameof(CategoryDto.Name));
            ViewBag.Cities = new SelectList(mapper.Map<CityDto[]>(await context.Cities.ToListAsync()), nameof(City.Id), nameof(City.Name));
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

        public UserController(OlxDBContext context, IWebHostEnvironment env, IConfiguration config, IMapper mapper) :base(context, mapper)
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

        public async Task<IActionResult> ShowAdvert(int id)
        {
            var advert = await adverts.FirstOrDefaultAsync(x => x.Id == id);
            ViewBag.Images = mapper.Map<ImageDto[]>(advert.Images);
            return View(mapper.Map<AdvertDto>(advert));
        }

        public async Task<IActionResult> DeleteElement(int id, [FromServices] AdvertRemover remover, [FromServices] IWebHostEnvironment env, [FromServices] IConfiguration config)
        {
            await remover.RemoveAdvert(id, context,env,config);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddAdvert(int id)
        {
            await setDataToBag();
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
