using ECommerceAPI.Persistence.Extensions.DbContexts;
using ECommerceAPI.Persistence.Extensions.Identity;
using ECommerceAPI.Persistence.Extensions.Repositories.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence.Extensions
{
    public static class PersistenceServiceCollection
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContexts(configuration)
                    .AddIdentity();

            services.AddBaseRepository();

            return services;
        }
    }
}