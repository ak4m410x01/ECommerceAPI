using ECommerceAPI.Presentation.Extensions.ServiceCollections.Authentication.Options;
using ECommerceAPI.Shared.Helpers.JwtConfiguration;
using Microsoft.Extensions.Options;

namespace ECommerceAPI.Presentation.Extensions.ServiceCollections.Authentication
{
    public static class AuthenticationServiceCollection
    {
        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthenticationOptions()
                    .AddJwtBearerOptions(configuration);

            return services;
        }
    }
}