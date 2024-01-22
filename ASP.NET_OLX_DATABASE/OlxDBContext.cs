using ASP.NET_OLX_DATABASE.Entities.Configs;
using ASP.NET_OLX_DATABASE.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_OLX_DATABASE
{
    public class OlxDBContext : DbContext
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
            DefaultData.Initialize(modelBuilder);
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Advert> Adverts { get; set; }
    }
}
