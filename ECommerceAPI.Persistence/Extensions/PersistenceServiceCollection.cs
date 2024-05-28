using ECommerceAPI.Persistence.Extensions.DbContexts;
using ECommerceAPI.Persistence.Extensions.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence.Extensions
{
    public static class PersistenceServiceCollection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContexts(configuration)
                    .AddIdentity();
            return services;
        }
    }
}
