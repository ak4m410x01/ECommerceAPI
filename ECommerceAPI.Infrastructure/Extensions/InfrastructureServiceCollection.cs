using ECommerceAPI.Infrastructure.Extensions.Authentication;
using ECommerceAPI.Infrastructure.Extensions.Media;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Infrastructure.Extensions
{
    public static class InfrastructureServiceCollection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTokenService(configuration);
            services.AddAuthenticationService();
            services.AddMediaService();
            return services;
        }
    }
}