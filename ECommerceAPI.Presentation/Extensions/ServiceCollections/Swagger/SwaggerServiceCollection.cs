using ECommerceAPI.Presentation.Extensions.ServiceCollections.Swagger.ServiceCollections;

namespace ECommerceAPI.Presentation.Extensions.ServiceCollections.Swagger
{
    public static class SwaggerServiceCollection
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGenOptions(configuration);
            return services;
        }
    }
}
