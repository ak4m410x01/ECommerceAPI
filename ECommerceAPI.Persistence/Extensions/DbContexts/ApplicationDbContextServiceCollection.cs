﻿using ECommerceAPI.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence.Extensions.DbContexts
{
    internal static class ApplicationDbContextServiceCollection
    {
        public static IServiceCollection AddApplicationDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Get Connection String From appsettings.json
            string? connectionString = configuration.GetConnectionString("DefaultConnection");

            // Add Application Db Context
            services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseLazyLoadingProxies().UseSqlServer(connectionString, builder =>
                                builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            return services;
        }
    }
}