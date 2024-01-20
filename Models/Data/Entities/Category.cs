namespace ASP.NET_OLX.Models.Data.Entities
{
    public class Category:BaseEntity
    {
       public string Name { get; set; }
       public ICollection<SaleAd> SaleAds { get; set; } = new HashSet<SaleAd>();
    }
}
