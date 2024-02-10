using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities.Configs
{
	internal class OrderConfig : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasOne(x=>x.User)
				   .WithMany(x=>x.Orders)
				   .HasForeignKey(x=>x.UserId)
				   .OnDelete(DeleteBehavior.NoAction);
			builder.HasOne(x => x.Advert)
				   .WithMany(x => x.Orders)
				   .HasForeignKey(x => x.AdvertId)
				   .OnDelete(DeleteBehavior.NoAction);
			builder.HasOne(x => x.City).WithMany(x => x.Orders).HasForeignKey(x => x.CityId);
			builder.Property(x=>x.Surname).HasMaxLength(60);
			builder.Property(x => x.Branch).HasMaxLength(120);
			builder.Property(x => x.Name).HasMaxLength(60);
			builder.Property(x => x.SecondName).HasMaxLength(60);
			builder.Property(x => x.Phone).HasMaxLength(25);
			builder.ToTable(t => t.HasCheckConstraint("Surname_check", "[Surname] <> ''"));
			builder.ToTable(t => t.HasCheckConstraint("Name_check", "[Name] <> ''"));
			builder.ToTable(t => t.HasCheckConstraint("SecondName_check", "[SecondName] <> ''"));
			builder.ToTable(t => t.HasCheckConstraint("Phone_check", "[Phone] <> ''"));
			builder.ToTable(t => t.HasCheckConstraint("Branch_check", "[Branch] <> ''"));
		}
	}
}
