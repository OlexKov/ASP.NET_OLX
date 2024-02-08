using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities.Configs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataAccess
{
	public class OlxDBContext : IdentityDbContext<User>
	{
		public OlxDBContext(DbContextOptions options) : base(options)
		{
			//Database.EnsureDeleted();
			//Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration<City>(new CityConfig());
			modelBuilder.ApplyConfiguration<Image>(new ImageConfig());
			modelBuilder.ApplyConfiguration<Category>(new CategoryConfig());
			modelBuilder.ApplyConfiguration<Advert>(new AdvertConfig());
            modelBuilder.ApplyConfiguration<UserFavouriteAdvert>(new UserFavouriteAdvertConfig());
            DefaultData.Initialize(modelBuilder);
        }

		public DbSet<City> Cities { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Image> Images { get; set; }

		public DbSet<Advert> Adverts { get; set; }

        public DbSet<UserFavouriteAdvert> UserFavouriteAdverts { get; set; }
    }
}
