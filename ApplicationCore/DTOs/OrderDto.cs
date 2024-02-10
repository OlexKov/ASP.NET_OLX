using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
	public class OrderDto
	{
		public int AdvertId { get; set; }
		public AdvertDto Advert { get; set; }
		public DateTime OrderDate { get; set; }
	}
}
