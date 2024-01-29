using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace ASP.NET_OLX
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
