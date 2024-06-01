using ECommerceAPI.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Interfaces.Services.Authentication
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(ApplicationUser user);
    }
}