using ECommerceAPI.Presentation.Extensions.ServiceCollections.ApiVersioning;
using ECommerceAPI.Presentation.Extensions.ServiceCollections.Authentication;
using ECommerceAPI.Presentation.Extensions.ServiceCollections.Authorization;
using ECommerceAPI.Presentation.Extensions.ServiceCollections.Cors;
using ECommerceAPI.Presentation.Extensions.ServiceCollections.Exceptions;
using ECommerceAPI.Presentation.Extensions.ServiceCollections.Swagger;

namespace ECommerceAPI.Presentation.Extensions.ServiceCollections
{
    public static class PresentationServiceCollection
    {
        public static IServiceCollection AddPresentationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region Configure Authentication

            services.AddAuthenticationConfigurations(configuration);

            #endregion Configure Authentication

            #region Configure Authorization

            services.AddAuthorizationConfigurations();

            #endregion Configure Authorization

            #region Configure Swagger/OpenAPI

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerConfiguration(configuration);

            #endregion Configure Swagger/OpenAPI

            services.AddCorsConfiguration();

            #region Configure Controllers

            services.AddControllers();

            #endregion Configure Controllers

            #region Configure Exceptions

            services.AddValidationErrorExceptionConfiguration();

            #endregion Configure Exceptions

            #region Configure Api Versioning

            services.AddApiVersioningConfiguration();

            #endregion Configure Api Versioning

            return services;
        }
    }
}