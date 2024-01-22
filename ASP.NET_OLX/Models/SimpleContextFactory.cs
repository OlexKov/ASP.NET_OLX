using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using ASP.NET_OLX_DATABASE;

namespace ASP.NET_OLX.Models
{
    public class SimpleContextFactory : IDesignTimeDbContextFactory<OlxDBContext>
    {
        public OlxDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OlxDBContext>();

            ConfigurationBuilder builder = new();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            string? connectionString = config.GetConnectionString("LocalDb");
            optionsBuilder.UseSqlServer(connectionString);
            return new OlxDBContext(optionsBuilder.Options);
        }
    }
}
