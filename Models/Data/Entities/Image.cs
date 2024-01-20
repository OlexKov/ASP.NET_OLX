namespace ASP.NET_OLX.Models.Data.Entities
{
    public class Image:BaseEntity
    {
        public string Url { get; set; }
        public ICollection<AdvertImage > Adverts { get; set; } = new HashSet<AdvertImage >();
    }
}
