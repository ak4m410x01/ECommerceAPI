using ECommerceAPI.Presentation.Extensions.ServiceCollections.Authentication.Options;
using ECommerceAPI.Shared.Helpers.JwtSettings;
using Microsoft.Extensions.Options;

namespace ECommerceAPI.Presentation.Extensions.ServiceCollections.Authentication
{
    public static class AuthenticationServiceCollection
    {
        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthenticationOptions()
                    .AddJwtBearerOptions(configuration);

            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<JwtSettings>>().Value);

            return services;
        }
    }
}