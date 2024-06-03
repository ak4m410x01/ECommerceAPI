using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerceAPI.Application.Extensions.AutoMapper
{
    public static class AutoMapperServiceCollection
    {
        public static IServiceCollection AddAutoMapperConfigurations(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}