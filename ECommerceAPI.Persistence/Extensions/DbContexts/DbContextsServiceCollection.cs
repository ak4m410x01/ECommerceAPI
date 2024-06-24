using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence.Extensions.DbContexts
{
    internal static class DbContextsServiceCollection
    {
        public static IServiceCollection AddDbContextsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDbContextConfiguration(configuration);
            return services;
        }
    }
}