namespace ASP.NET_OLX.Models.Data.Entities
{
    public class Category:BaseEntity
    {
       public string Name { get; set; }
        public ICollection<SaleAdvertisement> SaleAdvertisements { get; set; } = new HashSet<SaleAdvertisement>();
    }
}
