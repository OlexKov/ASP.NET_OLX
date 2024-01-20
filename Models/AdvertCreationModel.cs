using ASP.NET_OLX.Models.Data.Entities;

namespace ASP.NET_OLX.Models
{
    public class AdvertCreationModel
    {
        public string SellerName { get; set; }

        public string City { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsNew { get; set; }

        public decimal Price { get; set; }

        public List<IFormFile> Images { get; set; } = [];
    }
}
