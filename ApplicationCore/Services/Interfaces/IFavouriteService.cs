using ApplicationCore.DTOs;
using System.Threading.Tasks;

namespace ASP.NET_OLX.Services.Interfaces
{
	public interface IFavouriteService
	{
		Task<IEnumerable<AdvertDto>> GetFavouriteAdverts();
		Task Add(int id);
		Task Remove(int id);
		Task<int> GetCount();
		Task<bool> IsFavourite(int id);
    }
}
