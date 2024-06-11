using ECommerceAPI.Presentation.Extensions.ServiceCollections.Authentication.Options;
using ECommerceAPI.Shared.Helpers.JwtSettings;

namespace ECommerceAPI.Presentation.Extensions.ServiceCollections.Authentication
{
    public static class AuthenticationServiceCollection
    {
        public static IServiceCollection AddAuthenticationConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthenticationOptions()
                    .AddJwtBearerOptions(configuration);

            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
            services.AddSingleton(typeof(JwtSettings));
            return services;
        }
    }
}