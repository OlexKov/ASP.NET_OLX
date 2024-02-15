using Microsoft.AspNetCore.Http;

namespace ApplicationCore.Models
{
	public class AdvertModel
	{
		public int Id { get; set; }

		public string UserId { get; set; } = string.Empty;

		public int CityId { get; set; }

		public int CategoryId { get; set; }

		public string? Title { get; set; }

		public string? Description { get; set; }

		public bool IsNew { get; set; }

		public decimal Price { get; set; }

		public IEnumerable<string> ImagesUrls { get; set; } = [];

		public List<IFormFile> ImageFiles { get; set; } = [];
	}
}
