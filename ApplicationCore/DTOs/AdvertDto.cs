namespace ApplicationCore.DTOs
{
    public class AdvertDto : BaseEntityDto
	{
		public string SellerName { get; set; }

		public int CityId { get; set; }

		public string CityName { get; set; }

		public int CategoryId { get; set; }

		public string CategoryName { get; set; }

		public DateTime Date { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public bool IsNew { get; set; }

		public decimal Price { get; set; }

		public string FirstImage { get; set; }
	}
}
