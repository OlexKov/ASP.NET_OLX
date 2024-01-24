using ASP.NET_OLX_DATABASE.Entities;

namespace ASP.NET_OLX.Models
{
    public class AdvertModel
    {
        public int Id { get; set; }

        public string? SellerName { get; set; }

        public int CityId { get; set; }
      
        public int CategoryId { get; set; }

        public string? Title { get; set; }
        
        public string? Description { get; set; } 

        public bool IsNew { get; set; } 

        public decimal Price { get; set; } 

        public List<string> ImagesUrls { get; set; } = [];

        public List<IFormFile> Images { get; set; } = [];
    }
}
