namespace ASP.NET_OLX.Models.Data.Entities
{
    public class Image:BaseEntity
    {
        public string Url { get; set; }
        public ICollection<SaleAdvertisement> SaleAdvertisements { get; set; } = new HashSet<SaleAdvertisement>();
    }
}
