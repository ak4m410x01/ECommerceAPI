﻿using ECommerceAPI.Domain.IdentityEntities;
using ECommerceAPI.Persistence.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence.Extensions.Identity
{
    internal static class IdentityServiceCollection
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            // Identity Configuration
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();
            return services;
        }
    }
}