using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Users;
using ECommerceAPI.Domain.Enumerations.Users;
using ECommerceAPI.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Persistence.DataSeeding.Users
{
    public static class UsersDataSeeding
    {
        private static async Task InitializeAdminsAsync(this UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            ApplicationUser user = new()
            {
                UserName = "Admin",
                Email = "admin@ecommerceapi.com"
            };
            string password = "P@ssw0rd";

            await userManager.CreateAsync(user, password);
            await unitOfWork.Repository<UserProfile>().AddAsync(new UserProfile() { UserId = user.Id, Bio = string.Empty });
            await userManager.AddToRoleAsync(user, UserRole.Admin.ToString());
        }

        public static async Task InitializeUsersDataSeedingAsync(this UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            await userManager.InitializeAdminsAsync(unitOfWork);
        }
    }
}