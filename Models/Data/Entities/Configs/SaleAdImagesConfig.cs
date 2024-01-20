using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_OLX.Models.Data.Entities.Configs
{
    public class SaleAdImagesConfig : IEntityTypeConfiguration<AdvertImage >
    {
        public void Configure(EntityTypeBuilder<AdvertImage > builder)
        {
            builder.HasKey(x=>new {x.ImageId,x.AdvertId});
            builder.HasOne(x => x.Image)
                   .WithMany(x=>x.Adverts)
                   .HasForeignKey(x=>x.ImageId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Advert)
                    .WithMany(x => x.AdvertImages)
                    .HasForeignKey(x => x.AdvertId)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
