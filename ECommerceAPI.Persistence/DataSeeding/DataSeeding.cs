using ECommerceAPI.Application.Interfaces.UnitOfWork;
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

            bool isPendingMigrations = (await context.Database.GetPendingMigrationsAsync()).Any();

            if (isPendingMigrations)
            {
                await MigrateDatabaseAsync(context);

                #region Initialize Data

                await InitializeRolesDataAsync(services);

                await InitializeUserDataAsync(services);

                #endregion Initialize Data
            }
        }

        private static async Task MigrateDatabaseAsync(ApplicationDbContext context)
        {
            await context.Database.MigrateAsync();
        }

        private static async Task InitializeUserDataAsync(IServiceProvider services)
        {
            UserManager<ApplicationUser>? userManager = services.GetService<UserManager<ApplicationUser>>();
            var unitOfWork = services.GetService<IUnitOfWork>();

            if (userManager is null || unitOfWork is null)
                return;

            await userManager.InitializeUsersDataSeedingAsync(unitOfWork);
        }

        private static async Task InitializeRolesDataAsync(IServiceProvider services)
        {
            RoleManager<IdentityRole>? roleManager = services.GetService<RoleManager<IdentityRole>>();

            if (roleManager is null)
                return;

            await roleManager.InitializeRolesDataSeedingAsync();
        }
    }
}