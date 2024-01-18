using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_OLX.Models.Data.Entities.Configs
{
    public class SaleAdvertisementConfig : IEntityTypeConfiguration<SaleAdvertisement>
    {
        public void Configure(EntityTypeBuilder<SaleAdvertisement> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SellerName).HasMaxLength(256);
            builder.Property(x => x.Title);
            builder.Property(x => x.Description);
            builder.Property(x => x.Date);
            builder.HasOne(x=>x.City).WithMany(x=>x.SaleAdvertisements);
            builder.HasOne(x => x.Category).WithMany(x => x.SaleAdvertisements);
            builder.HasMany(x => x.Images).WithMany(x=>x.SaleAdvertisements);
            builder.ToTable(t => t.HasCheckConstraint("SellerName_check", "[SellerName] <> ''"));
            builder.ToTable(t => t.HasCheckConstraint("Title_check", "[Title] <> ''"));
            builder.ToTable(t => t.HasCheckConstraint("Description_check", "[Description] <> ''"));
        }
    }
}
