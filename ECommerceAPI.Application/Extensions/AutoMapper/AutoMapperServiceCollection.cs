using ECommerceAPI.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Application.Extensions.AutoMapper
{
    public static class AutoMapperServiceCollection
    {
        public static IServiceCollection AddAutoMapperConfigurations(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProfileMapper));
            return services;
        }
    }
}
