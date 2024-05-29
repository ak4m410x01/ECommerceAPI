using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Interfaces.DataSeeding.Security.Roles
{
    public interface IRoleSeeder : IBaseSeeder
    {
        Task<int> SeedRolesAsync(IEnumerable<IdentityRole> roles);
    }
}
