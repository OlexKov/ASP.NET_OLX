using ApplicationCore.DTOs;
using System.Threading.Tasks;

namespace ASP.NET_OLX.Services.Interfaces
{
	public interface IFavouriteService
	{
		Task<IEnumerable<AdvertDto>> GetFavouriteAdverts();
		void Add(int id);
		void Remove(int id);
		int GetCount();
		bool IsFavourite(int id);
    }
}
