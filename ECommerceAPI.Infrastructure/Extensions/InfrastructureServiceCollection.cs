using ECommerceAPI.Infrastructure.Extensions.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Infrastructure.Extensions
{
    public static class InfrastructureServiceCollection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddTokenService();
            services.AddAuthenticationService();
            return services;
        }
    }
}