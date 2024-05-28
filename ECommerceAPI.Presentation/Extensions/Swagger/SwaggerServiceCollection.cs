using ECommerceAPI.Presentation.Extensions.Swagger.ServiceCollections;

namespace ECommerceAPI.Presentation.Extensions.Swagger
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
