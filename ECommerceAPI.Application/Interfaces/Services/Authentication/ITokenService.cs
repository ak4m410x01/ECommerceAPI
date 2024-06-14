using ECommerceAPI.Application.DTOs.Authentication.Token;
using ECommerceAPI.Domain.IdentityEntities;

namespace ECommerceAPI.Application.Interfaces.Services.Authentication
{
    public interface ITokenService
    {
        Task<AccessTokenDTO> GenerateAccessTokenAsync(ApplicationUser user);

        Task<RefreshTokenDTO> GenerateRefreshTokenAsync(ApplicationUser user);
    }
}