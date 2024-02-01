using ApplicationCore.Expressions;
using ApplicationCore.Services;
using ApplicationCore.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationCore.Expressions
{
    public static class ServiceExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
        public static void AddFluentValidator(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            // enable client-side validation
            services.AddFluentValidationClientsideAdapters();
            // Load an assembly reference rather than using a marker type.
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddAdvertSetvice(this IServiceCollection services)
        {
            services.AddScoped<IAdvertService, AdvertService>();
        }

        public static bool ContainsText(this string text, string sub)
        {
            throw new NotImplementedException("This method is not supposed to run on client");
        }

    }
}
