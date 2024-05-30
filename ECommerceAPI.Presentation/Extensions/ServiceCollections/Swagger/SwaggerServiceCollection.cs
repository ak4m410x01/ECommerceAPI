using ECommerceAPI.Presentation.Extensions.ServiceCollections.Swagger.ServiceCollections;

namespace ECommerceAPI.Presentation.Extensions.ServiceCollections.Swagger
{
    public static class SwaggerServiceCollection
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer()
                    .AddSwaggerGenOptions(configuration);
            return services;
        }
    }
}
