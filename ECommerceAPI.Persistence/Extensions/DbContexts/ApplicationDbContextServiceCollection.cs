using ECommerceAPI.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence.Extensions.DbContexts
{
    internal static class ApplicationDbContextServiceCollection
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            // Get Connection String From appsettings.json
            string? connectionString = configuration.GetConnectionString("LocalDevelopmentDbConnection");

            // Add Application Db Context
            services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(connectionString, builder =>
                                builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            return services;
        }
    }
}
