using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ECommerceAPI.Presentation.Extensions.Swagger.Options
{
    public static class SecurityDefinitionOptions
    {
        public static SwaggerGenOptions AddSecurityDefinitionOptions(this SwaggerGenOptions swagger)
        {
            swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Description = "Enter 'Bearer' [space] and then your valid token.",
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header,
            });
            return swagger;
        }
    }
}
