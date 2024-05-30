using ECommerceAPI.Domain.Enumerations.Users;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Persistence.DataSeeding.Security.Roles
{
    public static class RolesDataSeeding
    {
        public static async Task InitializeRolesDataSeedingAsync(this RoleManager<IdentityRole> roleManager)
        {
            foreach (string role in Enum.GetNames(typeof(UserRole)))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
