namespace ASP.NET_OLX.Models.Data.Entities
{
    public class Category:BaseEntity
    {
       public string Name { get; set; }
       public ICollection<Advert> Adverts { get; set; } = new HashSet<Advert>();
    }
}
