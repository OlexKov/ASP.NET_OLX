using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class UserFavouriteAdvert : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int AdvertId { get; set; }
        public Advert Advert { get; set; }
    }
}
