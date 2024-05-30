using ECommerceAPI.Presentation.Extensions.ServiceCollections.Swagger.Options;

namespace ECommerceAPI.Presentation.Extensions.ServiceCollections.Swagger.ServiceCollections
{
    public static class SwaggerGenServiceCollection
    {
        public static IServiceCollection AddSwaggerGenOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.AddSwaggerDocOptions(configuration)
                       .AddSecurityDefinitionOptions()
                       .AddSecurityRequirementOptions();
            });

            return services;
        }
    }
}
