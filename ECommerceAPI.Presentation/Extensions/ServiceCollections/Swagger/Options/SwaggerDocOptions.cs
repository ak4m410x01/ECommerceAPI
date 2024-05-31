using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ECommerceAPI.Presentation.Extensions.ServiceCollections.Swagger.Options
{
    public static class SwaggerDocOptions
    {
        public static SwaggerGenOptions AddSwaggerDocOptions(this SwaggerGenOptions swagger, IConfiguration configuration)
        {
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = configuration.GetValue<string>("SwaggerOptions:SwaggerDoc:OpenApiInfo:Title"),
                Version = configuration.GetValue<string>("SwaggerOptions:SwaggerDoc:OpenApiInfo:Version"),
                Description = configuration.GetValue<string>("SwaggerOptions:SwaggerDoc:OpenApiInfo:Description"),

                License = new OpenApiLicense
                {
                    Name = configuration.GetValue<string>("SwaggerOptions:SwaggerDoc:OpenApiInfo:OpenApiLicense:Name"),
                    Url = new Uri(configuration.GetValue<string>("SwaggerOptions:SwaggerDoc:OpenApiInfo:OpenApiLicense:Url") ?? "")
                },

                Contact = new OpenApiContact
                {
                    Name = configuration.GetValue<string>("SwaggerOptions:SwaggerDoc:OpenApiInfo:OpenApiContact:Name"),
                    Email = configuration.GetValue<string>("SwaggerOptions:SwaggerDoc:OpenApiInfo:OpenApiContact:Email"),
                    Url = new Uri(configuration.GetValue<string>("SwaggerOptions:SwaggerDoc:OpenApiInfo:OpenApiContact:Url") ?? "")
                },
            });
            return swagger;
        }
    }
}