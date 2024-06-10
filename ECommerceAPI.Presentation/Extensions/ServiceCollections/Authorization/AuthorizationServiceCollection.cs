namespace ECommerceAPI.Presentation.Extensions.ServiceCollections.Authorization
{
    public static class AuthorizationServiceCollection
    {
        public static IServiceCollection AddAuthorizationConfigurations(this IServiceCollection services)
        {
            services.AddAuthorization();
            return services;
        }
    }
}