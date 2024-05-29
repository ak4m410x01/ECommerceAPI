using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Persistence.DataSeeding.Security.Roles
{
    public static class RolesDataSeeding
    {
        public static async Task InitializeRolesDataSeedingAsync(this RoleManager<IdentityRole> roleManager)
        {
            string[] roles = ["Admin", "Customer"];

            foreach (string role in roles)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
