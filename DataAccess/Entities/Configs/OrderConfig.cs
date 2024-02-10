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
		}
	}
}
