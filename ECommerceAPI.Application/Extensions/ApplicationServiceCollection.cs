using ECommerceAPI.Application.Extensions.AutoMapper;
using ECommerceAPI.Application.Extensions.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Application.Extensions
{
    public static class ApplicationServiceCollection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapperConfigurations();
            services.AddValidationConfiguration();
            return services;
        }
    }
}