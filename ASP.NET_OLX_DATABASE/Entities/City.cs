namespace ASP.NET_OLX_DATABASE.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Advert> Adverts { get; set; } = new HashSet<Advert>();
    }
}
