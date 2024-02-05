using Microsoft.EntityFrameworkCore;
using DataAccess;
using ApplicationCore.Expressions;
using ASP.NET_OLX.Expressions;
using Microsoft.AspNetCore.Identity;

namespace ASP.NET_OLX
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connStr = builder.Configuration.GetConnectionString("LocalDb")!;

            builder.Services.AddDbContext(connStr);

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            })
               .AddDefaultTokenProviders()
               .AddDefaultUI()
               .AddEntityFrameworkStores<OlxDBContext>();
                       
            // Add services to the container.
            builder.Services.AddControllersWithViews();
           
            // auto mapper
            builder.Services.AddAutoMapper();

            // enable client-side validation
            builder.Services.AddFluentValidator();

			builder.Services.AddAdvertSetvice();

			builder.Services.AddFavouriteService();

			builder.Services.AddDistributedMemoryCache();

			builder.Services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromDays(30);
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
			});

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

			app.UseSession();

			app.MapRazorPages();

			app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
