using ECommerceAPI.Application.Interfaces.DataSeeding.Security.Roles;
using ECommerceAPI.Persistence.DbContexts;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Persistence.DataSeeding.Security.Roles
{
    public static class RolesDataSeeding
    {
        public static async Task InitializeRolesDataSeedingAsync(this ApplicationDbContext context, IRoleSeeder roleSeeder)
        {
            IdentityRole[] roles = [new IdentityRole("Admin"), new IdentityRole("Customer")];
            await roleSeeder.SeedRolesAsync(roles);
        }
    }
}
