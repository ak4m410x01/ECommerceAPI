using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Interfaces.DataSeeding.Security.Roles
{
    public interface IRoleSeeder : IBaseSeeder
    {
        Task SeedRolesAsync(IEnumerable<IdentityRole> roles);
    }
}
