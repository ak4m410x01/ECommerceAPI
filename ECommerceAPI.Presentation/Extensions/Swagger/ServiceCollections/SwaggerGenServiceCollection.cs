using ECommerceAPI.Presentation.Extensions.Swagger.Options;

namespace ECommerceAPI.Presentation.Extensions.Swagger.ServiceCollections
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
