using ApplicationCore.Expressions;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using ApplicationCore.Services.Interfaces;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationCore.Expressions
{
    public static class ServiceExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
			services.AddSingleton(provider => new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AdvertProfile(provider.CreateScope().ServiceProvider.GetService<IConfiguration>()));

			}).CreateMapper());
		}
        public static void AddFluentValidator(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
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
