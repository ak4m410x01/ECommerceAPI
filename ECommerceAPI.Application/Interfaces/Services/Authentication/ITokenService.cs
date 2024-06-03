using ECommerceAPI.Domain.IdentityEntities;

namespace ECommerceAPI.Application.Interfaces.Services.Authentication
{
    public interface ITokenService
    {
        Task<(string value, DateTime validTo)> CreateTokenAsync(ApplicationUser user);
    }
}