using ECommerceAPI.Presentation.Extensions.ServiceCollections.Authentication;
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

            #region Configure Swagger/OpenAPI

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerConfiguration(configuration);

            #endregion Configure Swagger/OpenAPI

            #region Configure Controllers

            services.AddControllers();

            #endregion Configure Controllers

            return services;
        }
    }
}