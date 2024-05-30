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
            #endregion

            #region Configure Swagger/OpenAPI
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerConfiguration(configuration);
            #endregion

            #region Configure Controllers
            services.AddControllers();
            #endregion

            return services;
        }
    }
}
