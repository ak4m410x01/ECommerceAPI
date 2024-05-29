using ECommerceAPI.Domain.IdentityEntities;
using ECommerceAPI.Persistence.DataSeeding.Security.Roles;
using ECommerceAPI.Persistence.DataSeeding.Users;
using ECommerceAPI.Persistence.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence.DataSeeding
{
    public static class DataSeeding
    {
        public static async Task Initialize(IServiceProvider services)
        {
            ApplicationDbContext? context = services.GetService<ApplicationDbContext>();

            if (context is null)
                return;

            if (context.Database.GetPendingMigrationsAsync().Result.Any())
            {
                context.Database.MigrateAsync().Wait();

                UserManager<ApplicationUser>? userManager = services.GetService<UserManager<ApplicationUser>>();
                RoleManager<IdentityRole>? roleManager = services.GetService<RoleManager<IdentityRole>>();

                if (userManager is null || roleManager is null)
                    return;

                await roleManager.InitializeRolesDataSeedingAsync();
                await userManager.InitializeUsersDataSeedingAsync();
            }
        }
    }
}