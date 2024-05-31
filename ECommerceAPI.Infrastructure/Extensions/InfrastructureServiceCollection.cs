using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Infrastructure.Extensions
{
    public static class InfrastructureServiceCollection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            return services;
        }
    }
}