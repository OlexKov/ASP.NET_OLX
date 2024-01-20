namespace ASP.NET_OLX.Models.Data.Entities
{
    public class City:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<SaleAd> SaleAds { get; set; } = new HashSet<SaleAd>();
    }
}
