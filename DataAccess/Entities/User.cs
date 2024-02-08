using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities
{
	public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public ICollection<Advert> Adverts { get; set; } = new HashSet<Advert>();
        public ICollection<UserFavouriteAdvert> UserFavouriteAdverts { get; set; } = new HashSet<UserFavouriteAdvert>();
    }
}
