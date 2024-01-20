namespace ASP.NET_OLX.Models.Data.Entities
{
    public class Advert:BaseEntity
    {
        public string SellerName { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsNew { get; set; }

        public decimal Price { get; set; }

        public ICollection<AdvertImage > AdvertImages { get; set; } = new HashSet<AdvertImage >();
    } 
}
