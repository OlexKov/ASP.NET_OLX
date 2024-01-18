using ASP.NET_OLX.Models.Data.Entities;
using ASP.NET_OLX.Models.Data.Entities.Configs;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_OLX.Models.Data
{
    public class OlxDBContext:DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<City>(new CityConfig());
            modelBuilder.ApplyConfiguration<Image>(new ImageConfig());
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfig());
            modelBuilder.ApplyConfiguration<SaleAdvertisement>(new SaleAdvertisementConfig());
            DefaultData.Initialize(modelBuilder);
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<SaleAdvertisement> SaleAdvertisements { get; set; }
    }
}
