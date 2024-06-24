using ECommerceAPI.Application.Extensions;
using ECommerceAPI.Infrastructure.Extensions;
using ECommerceAPI.Persistence.DataSeeding;
using ECommerceAPI.Persistence.Extensions;
using ECommerceAPI.Presentation.Extensions.Middlewares;
using ECommerceAPI.Presentation.Extensions.ServiceCollections;

namespace ECommerceAPI.Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            #region Create Web Application

            var builder = WebApplication.CreateBuilder(args);

            #endregion Create Web Application

            #region Clean Architecture Layers Configuration

            builder.Services.AddApplicationLayer()
                            .AddInfrastructureLayer()
                            .AddPersistenceLayer(builder.Configuration)
                            .AddPresentationLayer(builder.Configuration);

            #endregion Clean Architecture Layers Configuration

            #region Build Web Application

            var app = builder.Build();

            #endregion Build Web Application

            #region Use App Middlewares

            app.UsePresentationMiddlewares();

            #endregion Use App Middlewares

            app.MapControllers();

            #region Data Seeding

            await DataSeeding.Initialize(app.Services.CreateAsyncScope().ServiceProvider);

            #endregion Data Seeding

            #region Run Web Application

            app.Run();

            #endregion Run Web Application
        }
    }
}