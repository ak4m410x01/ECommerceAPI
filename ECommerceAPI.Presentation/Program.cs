using ECommerceAPI.Infrastructure.Extensions;
using ECommerceAPI.Persistence.DataSeeding;
using ECommerceAPI.Persistence.Extensions;
using ECommerceAPI.Presentation.Extensions.Swagger;

namespace ECommerceAPI.Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            #region Create Web Application
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
            #endregion

            // Add services to the container.

            #region Clean Architecture Layers Configuration
            builder.Services.AddInfrastructure()
                            .AddPersistence(builder.Configuration);
            #endregion

            builder.Services.AddControllers();

            #region Configure Swagger/OpenAPI
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagger(builder.Configuration);
            #endregion

            #region Build Web Application
            WebApplication? app = builder.Build();
            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                #region Configure Swagger/OpenAPI Pipeline
                app.UseSwagger();
                app.UseSwaggerUI();
                #endregion
            }

            #region Config Authentication & Authorization Pipelines
            app.UseAuthorization();
            #endregion

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
