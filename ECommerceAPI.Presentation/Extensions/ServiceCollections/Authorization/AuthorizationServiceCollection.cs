using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace ECommerceAPI.Presentation.Extensions.ServiceCollections.Authorization
{
    public static class AuthorizationServiceCollection
    {
        public static IServiceCollection AddAuthorizationConfigurations(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });
            return services;
        }
    }
}