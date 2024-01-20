using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_OLX.Models.Data.Entities.Configs
{
    public class SaleAdImagesConfig : IEntityTypeConfiguration<SaleAdImage>
    {
        public void Configure(EntityTypeBuilder<SaleAdImage> builder)
        {
            builder.HasKey(x=>new {x.ImageId,x.SaleAdId});
            builder.HasOne(x => x.Image)
                   .WithMany(x=>x.SaleAds)
                   .HasForeignKey(x=>x.ImageId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.SaleAd)
                    .WithMany(x => x.SaleAdImages)
                    .HasForeignKey(x => x.SaleAdId)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
