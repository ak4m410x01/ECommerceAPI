using ECommerceAPI.Application.Extensions;
using ECommerceAPI.Infrastructure.Extensions;
using ECommerceAPI.Persistence.DataSeeding;
using ECommerceAPI.Persistence.Extensions;
using ECommerceAPI.Presentation.Extensions.MiddleWares;
using ECommerceAPI.Presentation.Extensions.MiddleWares.Exceptions;
using ECommerceAPI.Presentation.Extensions.MiddleWares.Swagger;
using ECommerceAPI.Presentation.Extensions.ServiceCollections;
using ECommerceAPI.Presentation.MiddleWares;
using ECommerceAPI.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            #region Create Web Application

            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

            #endregion Create Web Application

            #region Clean Architecture Layers Configuration

            builder.Services.AddApplicationLayer()
                            .AddInfrastructureLayer()
                            .AddPresentationLayer(builder.Configuration)
                            .AddPersistenceLayer(builder.Configuration);

            #endregion Clean Architecture Layers Configuration

            #region Build Web Application

            WebApplication? app = builder.Build();

            #endregion Build Web Application

            app.UsePresentationMiddleWares(app.Environment);

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    #region Configure Swagger/OpenAPI Pipeline

            // app.UseSwaggerMiddleWares();

            //    #endregion Configure Swagger/OpenAPI Pipeline
            //}

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