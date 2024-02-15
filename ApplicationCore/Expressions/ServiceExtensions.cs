using ApplicationCore.Helpers;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using ApplicationCore.Services.Interfaces;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;

namespace ApplicationCore.Expressions
{
    public static class ServiceExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AdvertProfile(provider.CreateScope().ServiceProvider.GetService<IConfiguration>()!));
                cfg.AddProfile(new OrderProfile());
            }).CreateMapper());
        }
        public static void AddFluentValidator(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAdvertService, AdvertService>();
			services.AddMailKit(optionBuilder =>
            {
                MailSettings? settings = configuration.GetSection("UkrNetMailSettings").Get<MailSettings>();
                if (settings == null) throw new ArgumentNullException(nameof(settings));
                optionBuilder.UseMailKit(new MailKitOptions()
                {
                    Server = settings.Server,
                    Port = settings.Port,
                    SenderName = settings.SenderName,
                    SenderEmail = settings.SenderEmail,
                    Account = settings.Account,
                    Password = settings.Password,
                    Security = true
                });
            });
        }
    }
}
