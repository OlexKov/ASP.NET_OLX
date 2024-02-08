using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class ServiceExtentions
	{
		public static void AddDbContext(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<OlxDBContext>( opts =>
				opts.UseSqlServer(connectionString));
		}
	}
}
