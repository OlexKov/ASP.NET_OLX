using ApplicationCore.DTOs;
using ApplicationCore.Models;
using ApplicationCore.Services.Interfaces;
using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;

using Image = DataAccess.Entities.Image;

namespace ApplicationCore.Services
{
	internal class AdvertService : IAdvertService
	{
		private OlxDBContext context;
		private IWebHostEnvironment env;
		private IConfiguration config;
		private IMapper mapper;
		private readonly IIncludableQueryable<Advert, ICollection<Image>> adverts;

		public AdvertService(OlxDBContext context, IWebHostEnvironment env, IConfiguration config, IMapper mapper) 
		{
			this.context = context;
			this.env = env;
			this.config = config;
			this.mapper = mapper;
			adverts = context.Adverts.Include(x => x.Category).Include(x => x.City).Include(x => x.Images);
		}


		private async Task<string> saveImage(IFormFile file/*,string scheme, HostString host*/)
		{
			string fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
			string filePath = Path.Combine(env.WebRootPath, config["UserImgDir"] ?? string.Empty, fileName);
			using Stream fileStream = new FileStream(filePath, FileMode.Create);
			await file.CopyToAsync(fileStream);
			return fileName;
        }


		public async Task<AdvertDto> GetAdvert(int id)
		{
			var advert = await adverts.FirstOrDefaultAsync(x => x.Id == id);
			var advertDto = mapper.Map<AdvertDto>(advert);
			advertDto.FirstImage = advert?.Images.ElementAt(0).Name ?? string.Empty;
			return advertDto;
		}

		public async Task<IEnumerable<AdvertDto>> GetAllAdverts()
		{
			return mapper.Map<IEnumerable<AdvertDto>>(await adverts.ToArrayAsync());
		}

		public async Task RemoveAdvert(int id)
		{
			var images = context.Images.Where(x => x.AdvertId == id);
			foreach (var image in images)
				File.Delete(Path.Combine(env.WebRootPath, config["UserImgDir"] ?? string.Empty, Path.GetFileName(image.Name)));
			var advert = await context.Adverts.FindAsync(id) ?? new();
			context.Images.RemoveRange(images);
			context.Adverts.Remove(advert);
			await context.SaveChangesAsync();
		}

		public async Task<IEnumerable<ImageDto>> GetAdvertImages(int id)
		{
		    return mapper.Map<IEnumerable<ImageDto>>((await adverts.FirstOrDefaultAsync(x => x.Id == id))?.Images);
		}

		public async Task<IEnumerable<CategoryDto>> GetAllCategories()
		{
			return mapper.Map<IEnumerable<CategoryDto>>( await context.Categories.ToArrayAsync());
		}

		public async Task<IEnumerable<CityDto>> GetAllCities()
		{
			return mapper.Map<IEnumerable<CityDto>>(await context.Cities.ToArrayAsync());
		}

		public async Task CreateAdvert(AdvertModel advertModel)
		{
			Advert? advert;

			if (advertModel.Id != 0)
				advert = mapper.Map<Advert>(advertModel);
			else
			{
				advert = mapper.Map<Advert>(advertModel);
				advert.Date = DateTime.Now;
			}

			foreach (var item in advertModel.ImageFiles)
				advert.Images.Add(new Image() { Name = await saveImage(item) });

			if (advertModel.Id == 0)
				await context.Adverts.AddAsync(advert);
			else
				context.Adverts.Update(advert);

			await context.SaveChangesAsync();
		}

		public async Task<ImageDto> GetImage(string url)
		{
			return mapper.Map<ImageDto>( await context.Images.FirstOrDefaultAsync(x => x.Name == url) ?? new());
		}

		public async Task RemoveImage(string url)
		{
			var deleteImage = await context.Images.FirstOrDefaultAsync(x => x.Name == url) ?? new();
			context.Images.Remove(deleteImage);
			await context.SaveChangesAsync();
			File.Delete(Path.Combine(env.WebRootPath, config["UserImgDir"] ?? string.Empty, Path.GetFileName(url)));
		}

		public async Task<AdvertModel> GetAdvertModel(int id)
		{
			var advert = await adverts.FirstOrDefaultAsync(x => x.Id == id);
			var advertModel = mapper.Map<AdvertModel>(advert);
			return advertModel;
		}

		public async Task<IEnumerable<AdvertDto>> AdvertFilter(string sort, string category, string state, decimal from, decimal to, string? find, string fcity)
		{
            find = find?.ToLower() ?? string.Empty;
			var filteredAdverts = adverts.Where(x => (category == "Всі категорії" || x.Category.Name == category)
																	   && (state == "all" || (state == "new" && x.IsNew) || (state == "used" && !x.IsNew))
																	   && ((from == 0 && to == 0) || (x.Price >= from && (to == 0 || x.Price <= to)))
																	   && ((fcity == "Всі міста" && String.IsNullOrEmpty(find)) || (String.IsNullOrEmpty(find) && fcity == x.City.Name))
																	   /*&& ((fcity == "Всі міста" && x.Title.ToLower().Contains(find)) || (fcity == x.City.Name && x.Title.ToLower().Contains(find)))*/);


			var sortedAdverts = sort == null
				 ? filteredAdverts
				 : sort == "date"
				 ? filteredAdverts.OrderBy(x => x.Date)
				 : filteredAdverts.OrderBy(x => x.Title);
			return mapper.Map<AdvertDto[]>(await sortedAdverts.ToArrayAsync());
        }
    }
}
