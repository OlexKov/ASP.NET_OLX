using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
	public class Order :BaseEntity
	{
		public int AdvertId { get; set; }
		public Advert Advert { get; set; }
		public string UserId { get; set; }
		public User User { get; set; }
		public DateTime OrderDate { get; set; }


		public string Postal { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string SecondName { get; set; }
		public int CityId { get; set; }
		public City City { get; set; }
		public string Branch { get; set; }
		public string Phone { get; set; }
	}
}
