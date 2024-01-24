using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ASP.NET_OLX_DATABASE;
using ASP.NET_OLX.Services;
using ASP.NET_OLX.Services.Interfaces;

namespace ASP.NET_OLX
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connStr = builder.Configuration.GetConnectionString("LocalDb");

            builder.Services.AddDbContext<OlxDBContext>(opts => opts.UseSqlServer(connStr));
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

          
            // enable client-side validation
            builder.Services.AddFluentValidationClientsideAdapters();

            builder.Services.AddFluentValidationAutoValidation();

            // Load an assembly reference rather than using a marker type.
            builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<AdvertRemover>(x=> new());

            // auto mapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
