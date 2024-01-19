using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_OLX.Models.Data.Entities.Configs
{
    public class SaleAdvertisementsImagesConfig : IEntityTypeConfiguration<SaleAdvertisementImage>
    {
        public void Configure(EntityTypeBuilder<SaleAdvertisementImage> builder)
        {
            builder.HasKey(x=>new {x.ImageId,x.SaleAdvertisementId});
            builder.HasOne(x => x.Image)
                   .WithMany(x=>x.SaleAdvertisements)
                   .HasForeignKey(x=>x.ImageId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.SaleAdvertisement)
                    .WithMany(x => x.SaleAdvertisementsImages)
                    .HasForeignKey(x => x.SaleAdvertisementId)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
