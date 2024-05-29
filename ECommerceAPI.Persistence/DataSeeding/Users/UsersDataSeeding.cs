using ECommerceAPI.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Persistence.DataSeeding.Users
{
    public static class UsersDataSeeding
    {
        private static async Task InitializeAdminsAsync(this UserManager<ApplicationUser> userManager)
        {
            ApplicationUser user = new()
            {
                UserName = "Admin",
                Email = "admin@ecommerceapi.com"
            };
            string password = "P@ssw0rd";

            await userManager.CreateAsync(user, password);
            await userManager.AddToRoleAsync(user, "Admin");
        }

        public static async Task InitializeUsersDataSeedingAsync(this UserManager<ApplicationUser> userManager)
        {
            await userManager.InitializeAdminsAsync();
        }
    }
}
