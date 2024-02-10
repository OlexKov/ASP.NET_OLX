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
	}
}
