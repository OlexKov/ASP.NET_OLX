﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ASP.NET_OLX_DATABASE.Entities;

namespace ASP.NET_OLX_DATABASE.Entities.Configs
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Url).IsRequired();
            builder.HasOne(x => x.Advert).WithMany(x => x.Images).HasForeignKey(x => x.AdvertId);
            builder.ToTable(t => t.HasCheckConstraint("Url_check", "[Url] <> ''"));

        }
    }
}