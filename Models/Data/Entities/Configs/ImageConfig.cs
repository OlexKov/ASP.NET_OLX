using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_OLX.Models.Data.Entities.Configs
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Url).IsRequired();
            builder.HasIndex(x => x.Url).IsUnique();
            builder.ToTable(t => t.HasCheckConstraint("Url_check", "[Url] <> ''"));
        }
    }
}
