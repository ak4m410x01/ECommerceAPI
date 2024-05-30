using ECommerceAPI.Application.Extensions;
using ECommerceAPI.Infrastructure.Extensions;
using ECommerceAPI.Persistence.DataSeeding;
using ECommerceAPI.Persistence.Extensions;
using ECommerceAPI.Presentation.Extensions.Middlewares.Swagger;
using ECommerceAPI.Presentation.Extensions.ServiceCollections;

namespace ECommerceAPI.Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            #region Create Web Application
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
            #endregion

            #region Clean Architecture Layers Configuration
            builder.Services.AddApplicationLayer()
                            .AddInfrastructureLayer()
                            .AddPresentationLayer(builder.Configuration)
                            .AddPersistenceLayer(builder.Configuration);
            #endregion

            #region Build Web Application
            WebApplication? app = builder.Build();
            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                #region Configure Swagger/OpenAPI Pipeline
                app.UseSwaggerMiddlewares();
                #endregion
            }

            app.MapControllers();

            #region Data Seeding
            await DataSeeding.Initialize(app.Services.CreateAsyncScope().ServiceProvider);
            #endregion

            #region Run Web Application
            app.Run();
            #endregion
        }
    }
}
