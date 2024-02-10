
using DataAccess.Migrations;

namespace DataAccess.Entities
{
	public class City : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Advert> Adverts { get; set; } = new HashSet<Advert>();
		public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
	}
}
