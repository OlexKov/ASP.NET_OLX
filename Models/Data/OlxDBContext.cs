using ASP.NET_OLX.Models.Data.Entities;
using ASP.NET_OLX.Models.Data.Entities.Configs;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_OLX.Models.Data
{
    public class OlxDBContext:DbContext
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
            modelBuilder.ApplyConfiguration<SaleAd>(new SaleAdConfig());
            modelBuilder.ApplyConfiguration<SaleAdImage>(new SaleAdImagesConfig());
            DefaultData.Initialize(modelBuilder);
        }
       
        public DbSet<City> Cities { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<SaleAd> SaleAds { get; set; }

        public DbSet<SaleAdImage> SaleAdImages { get; set; }
    }
}
