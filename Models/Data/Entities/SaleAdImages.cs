namespace ASP.NET_OLX.Models.Data.Entities
{
    public class SaleAdImage:BaseEntity
    {
        public int ImageId { get; set; }
        public int SaleAdId { get; set; }
        public Image Image { get; set; }
        public SaleAd SaleAd { get; set; }
    }
}
