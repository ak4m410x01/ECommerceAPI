using ECommerceAPI.Application.Interfaces.Services.Authentication;
using ECommerceAPI.Infrastructure.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Infrastructure.Extensions.Authentication
{
    public static class TokenServiceCollection
    {
        public static IServiceCollection AddTokenService(this IServiceCollection services)
        {
            services.AddScoped(typeof(ITokenService), typeof(TokenService));

            return services;
        }
    }
}