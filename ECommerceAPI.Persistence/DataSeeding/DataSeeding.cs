using ECommerceAPI.Application.Interfaces.DataSeeding.Security.Roles;
using ECommerceAPI.Persistence.DataSeeding.Security.Roles;
using ECommerceAPI.Persistence.DbContexts;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence.DataSeeding
{
    public static class DataSeeding
    {
        public static async Task Initialize(IServiceProvider services, IRoleSeeder roleSeeder)
        {
            ApplicationDbContext? context = services.GetService<ApplicationDbContext>();

            if (context is null)
                return;

            await context.InitializeRolesDataSeedingAsync(roleSeeder);
        }
    }
}