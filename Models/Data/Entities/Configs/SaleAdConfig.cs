using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_OLX.Models.Data.Entities.Configs
{
    public class SaleAdConfig : IEntityTypeConfiguration<SaleAd>
    {
        public void Configure(EntityTypeBuilder<SaleAd> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SellerName).HasMaxLength(256);
            builder.Property(x => x.Title);
            builder.Property(x => x.Description);
            builder.Property(x => x.Date);
            builder.Property(x => x.IsNew);
            builder.Property(x => x.Price);
            builder.HasOne(x=>x.City).WithMany(x=>x.SaleAds);
            builder.HasOne(x => x.Category).WithMany(x => x.SaleAds);
            builder.ToTable(t => t.HasCheckConstraint("SellerName_check", "[SellerName] <> ''"));
            builder.ToTable(t => t.HasCheckConstraint("Title_check", "[Title] <> ''"));
            builder.ToTable(t => t.HasCheckConstraint("Description_check", "[Description] <> ''"));
        }
    }
}
