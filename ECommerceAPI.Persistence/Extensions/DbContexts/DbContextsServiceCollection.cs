using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence.Extensions.DbContexts
{
    internal static class DbContextsServiceCollection
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDbContext(configuration);
            return services;
        }
    }
}
