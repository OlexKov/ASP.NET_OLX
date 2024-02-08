using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Configs
{
    public class UserFavouriteAdvertConfig : IEntityTypeConfiguration<UserFavouriteAdvert>
    {
        public void Configure(EntityTypeBuilder<UserFavouriteAdvert> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.UserFavouriteAdverts).HasForeignKey(x=>x.UserId).OnDelete( DeleteBehavior.NoAction);
            builder.HasOne(x => x.Advert).WithMany(x => x.UserFavouriteAdverts).HasForeignKey(x => x.AdvertId);
        }
    }
}
