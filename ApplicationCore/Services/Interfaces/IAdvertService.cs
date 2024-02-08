using ApplicationCore.DTOs;
using ApplicationCore.Models;

namespace ApplicationCore.Services.Interfaces
{
    public interface IAdvertService
	{
		Task RemoveAdvert(int id);
		Task<IEnumerable<AdvertDto>> GetAllAdverts();
		Task<AdvertDto> GetAdvert(int id);
		Task<IEnumerable<AdvertDto>> GetAdverts(IEnumerable<int> ids);
		Task<IEnumerable<AdvertDto>> GetUserAdverts(string id);
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
