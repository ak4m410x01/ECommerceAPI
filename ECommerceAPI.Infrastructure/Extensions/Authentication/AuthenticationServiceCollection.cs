using ECommerceAPI.Application.Interfaces.Services.Authentication;
using ECommerceAPI.Infrastructure.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Infrastructure.Extensions.Authentication
{
    public static class AuthenticationServiceCollection
    {
        public static IServiceCollection AddAuthenticationService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAuthenticationService), typeof(AuthenticationService));
            return services;
        }
    }
}