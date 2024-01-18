namespace ASP.NET_OLX.Models.Data.Entities
{
    public class SaleAdvertisementImage:BaseEntity
    {
        public int ImageId { get; set; }
        public int SaleAdvertisementId { get; set; }
        public Image Image { get; set; }
        public SaleAdvertisement SaleAdvertisement { get; set; }
    }
}
