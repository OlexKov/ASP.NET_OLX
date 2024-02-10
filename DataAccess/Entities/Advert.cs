

namespace DataAccess.Entities
{
	public class Advert : BaseEntity
	{
		public string UserId { get; set; }

		public User User { get; set; }

		public int CityId { get; set; }

		public City City { get; set; }

		public int CategoryId { get; set; }

		public Category Category { get; set; }

		public DateTime Date { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public bool IsNew { get; set; }

		public decimal Price { get; set; }

		public ICollection<Image> Images { get; set; } = new HashSet<Image>();

		public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

		public ICollection<UserFavouriteAdvert> UserFavouriteAdverts { get; set; } = new HashSet<UserFavouriteAdvert>();

    }
}
