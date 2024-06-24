using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Users;
using ECommerceAPI.Domain.Enumerations.Users;
using ECommerceAPI.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Persistence.DataSeeding.Users
{
    public static class UsersDataSeeding
    {
        private static async Task InitializeSuperAdminsAsync(this UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            var superAdmin = new ApplicationUser()
            {
                Email = "superadmin@ecommerceapi.com",
                UserName = "superadmin"
            };
            await userManager.CreateAsync(superAdmin, "P@ssw0rd");
            await unitOfWork.Repository<UserProfile>().AddAsync(new UserProfile() { UserId = superAdmin.Id, Bio = string.Empty });
            await userManager.AddToRoleAsync(superAdmin, UserRole.SuperAdmin.ToString());
        }

        private static async Task InitializeAdminsAsync(this UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            var admin = new ApplicationUser()
            {
                UserName = "admin",
                Email = "admin@ecommerceapi.com"
            };

            await userManager.CreateAsync(admin, "P@ssw0rd");
            await unitOfWork.Repository<UserProfile>().AddAsync(new UserProfile() { UserId = admin.Id, Bio = string.Empty });
            await userManager.AddToRoleAsync(admin, UserRole.Admin.ToString());
        }

        public static async Task InitializeUsersDataSeedingAsync(this UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            await userManager.InitializeAdminsAsync(unitOfWork);
            await userManager.InitializeSuperAdminsAsync(unitOfWork);
        }
    }
}