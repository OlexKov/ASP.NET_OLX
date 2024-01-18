using ASP.NET_OLX.Models.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_OLX.Models.Data
{
    public static class DefaultData
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(Cities);
            modelBuilder.Entity<Category>().HasData(Categories);
            modelBuilder.Entity<Image>().HasData(Images);
            modelBuilder.Entity<SaleAdvertisement>().HasData(SaleAdvertisements);
        }

        public static readonly City[] Cities =
        {
            
        };

        public static readonly Category[] Categories =
        {
            
        };

        public static readonly Image[] Images =
        {
            
        };

        public static readonly SaleAdvertisement[] SaleAdvertisements =
        {
            
        };

        
    }
}

