
namespace DataAccess.Entities
{
	public class Image : BaseEntity
    {
        public string Url { get; set; }
        public int AdvertId { get; set; }
        public Advert Advert { get; set; }
    }
}
