using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ASP.NET_OLX_DATABASE.Entities;

namespace ASP.NET_OLX_DATABASE.Entities.Configs
{
    public class AdvertConfig : IEntityTypeConfiguration<Advert>
    {
        public void Configure(EntityTypeBuilder<Advert> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SellerName).HasMaxLength(256);
            builder.Property(x => x.Title);
            builder.Property(x => x.Description);
            builder.Property(x => x.Date);
            builder.Property(x => x.IsNew);
            builder.Property(x => x.Price).HasPrecision(12, 2);
            builder.HasOne(x => x.City).WithMany(x => x.Adverts);
            builder.HasOne(x => x.Category).WithMany(x => x.Adverts);
            builder.ToTable(t => t.HasCheckConstraint("SellerName_check", "[SellerName] <> ''"));
            builder.ToTable(t => t.HasCheckConstraint("Title_check", "[Title] <> ''"));
            builder.ToTable(t => t.HasCheckConstraint("Description_check", "[Description] <> ''"));
        }
    }
}
