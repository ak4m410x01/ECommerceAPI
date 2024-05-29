using ECommerceAPI.Application.Interfaces.DataSeeding.Security.Roles;
using ECommerceAPI.Persistence.DbContexts;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Infrastructure.DataSeeding.Security.Roles
{
    public class RoleSeeder : IRoleSeeder
    {
        private readonly ApplicationDbContext _context;

        public RoleSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> SeedRolesAsync(IEnumerable<IdentityRole> roles)
        {
            List<string?> existingRoles = _context.Roles.Select(r => r.Name).ToList();

            foreach (IdentityRole role in roles)
            {
                if (!existingRoles.Contains(role.Name))
                {
                    await _context.Roles.AddAsync(role);
                }
            }

            return await _context.SaveChangesAsync();
        }
    }
}
