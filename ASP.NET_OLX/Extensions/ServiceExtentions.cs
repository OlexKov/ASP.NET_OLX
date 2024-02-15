using ApplicationCore.Services.Interfaces;
using ASP.NET_OLX.Services;
using ASP.NET_OLX.Services.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ASP.NET_OLX.Expressions
{
	public static class ServiceExtentions
	{
		public static void AddFavouriteService(this IServiceCollection services)
		{
			services.AddScoped<IFavouriteService, FavouriteService>();
            services.AddScoped<IViewRender, ViewRender>();
        }
	}
}
