using Microsoft.EntityFrameworkCore;
using DataAccess;
using ApplicationCore.Expressions;

namespace ASP.NET_OLX
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connStr = builder.Configuration.GetConnectionString("LocalDb")!;

            builder.Services.AddDbContext(connStr);
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
           
            // auto mapper
            builder.Services.AddAutoMapper();

            // enable client-side validation
            builder.Services.AddFluentValidator();

			builder.Services.AddAdvertSetvice();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
