using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTOs
{
	public class OrderDto
	{
		public int AdvertId { get; set; }
		public string UserId { get; set; }
		public DateTime OrderDate { get; set; }

		public string? Postal { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? SecondName { get; set; }
		public int CityId { get; set; }
		public string? Branch { get; set; }
		[Phone(ErrorMessage ="Телефон введено не вірно")]
		[Required(ErrorMessage = "Вкажіть будьласка свій телефон")]
		[Display(Name = "Номер телефону")]
		public string? Phone { get; set; }
	}
}
