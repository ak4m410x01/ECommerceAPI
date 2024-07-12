using ECommerceAPI.Application.Interfaces.Services.Authentication;
using ECommerceAPI.Infrastructure.Services.Authentication;
using ECommerceAPI.Shared.Helpers.JwtConfiguration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ECommerceAPI.Infrastructure.Extensions.Authentication
{
    public static class TokenServiceCollection
    {
        public static IServiceCollection AddTokenService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtConfiguration>(configuration.GetSection("JwtConfiguration"));
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<JwtConfiguration>>().Value);

            services.AddScoped(typeof(ITokenService), typeof(TokenService));

            return services;
        }
    }
}