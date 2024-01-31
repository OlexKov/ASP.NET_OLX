using ApplicationCore.DTOs;
using ApplicationCore.Models;
using DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.Interfaces
{
	public interface IAdvertService
	{
		Task RemoveAdvert(int id);
		Task<IEnumerable<AdvertDto>> GetAllAdverts();
		Task<AdvertDto> GetAdvert(int id);
		Task<AdvertModel> GetAdvertModel(int id);
		Task<IEnumerable<ImageDto>> GetAdvertImages(int id);
		Task<IEnumerable<CategoryDto>> GetAllCategories();
		Task<IEnumerable<CityDto>> GetAllCities();
		Task CreateAdvert(AdvertModel advertModel);
		Task<ImageDto> GetImage(string url);
		Task RemoveImage(string url);
		Task<IEnumerable<AdvertDto>> AdvertFilter(string sort, string category, string state, decimal from, decimal to, string? find, string fcity);

    }
}
