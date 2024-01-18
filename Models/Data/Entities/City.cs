namespace ASP.NET_OLX.Models.Data.Entities
{
    public class City:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<SaleAdvertisement> SaleAdvertisements { get; set; } = new HashSet<SaleAdvertisement>();
    }
}
