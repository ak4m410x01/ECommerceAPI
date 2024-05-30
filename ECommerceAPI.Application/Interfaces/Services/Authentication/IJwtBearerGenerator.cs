using ECommerceAPI.Domain.IdentityEntities;

namespace ECommerceAPI.Application.Interfaces.Services.Authentication
{
    public interface IJwtBearerGenerator
    {
        string GenerateToken(ApplicationUser user);
    }
}
