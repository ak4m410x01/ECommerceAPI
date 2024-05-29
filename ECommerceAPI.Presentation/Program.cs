using ECommerceAPI.Application.Interfaces.DataSeeding.Security.Roles;
using ECommerceAPI.Infrastructure.DataSeeding.Security.Roles;
using ECommerceAPI.Persistence.DataSeeding;
using ECommerceAPI.Persistence.DbContexts;
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
            builder.Services.AddPersistence(builder.Configuration);
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
            IServiceProvider serviceProvider = app.Services.CreateScope().ServiceProvider;
            using (ApplicationDbContext? context = serviceProvider.GetService<ApplicationDbContext>())
            {
                if (context is not null)
                {
                    IRoleSeeder roleSeeder = new RoleSeeder(context);
                    await DataSeeding.Initialize(serviceProvider, roleSeeder);
                }
            }

            #endregion

            #region Run Web Application
            app.Run();
            #endregion
        }
    }
}
