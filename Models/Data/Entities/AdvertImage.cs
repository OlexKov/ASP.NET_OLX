namespace ASP.NET_OLX.Models.Data.Entities
{
    public class AdvertImage :BaseEntity
    {
        public int ImageId { get; set; }
        public int AdvertId { get; set; }
        public Image Image { get; set; }
        public Advert Advert { get; set; }
    }
}
