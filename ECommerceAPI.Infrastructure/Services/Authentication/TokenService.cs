using ECommerceAPI.Application.Interfaces.Services.Authentication;
using ECommerceAPI.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerceAPI.Infrastructure.Services.Authentication
{
    public class TokenService : ITokenService
    {
        #region Properties

        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        #endregion Properties

        #region Constructors

        public TokenService(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        #endregion Constructors

        #region Methods

        #region Create Token

        public async Task<(string value, DateTime validTo)> CreateTokenAsync(ApplicationUser user)
        {
            JwtSecurityToken token = new
            (
               issuer: _configuration["Jwt:Issuer"],
               audience: _configuration["Jwt:Audience"],
               expires: DateTime.UtcNow.AddDays(double.Parse(_configuration["Jwt:ExpireInDays"]!)),
               claims: await GetTokenClaimsAsync(user),
               signingCredentials: GetSigningCredentials()
            );

            return (new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo);
        }

        private SigningCredentials GetSigningCredentials()
        {
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            return new(key, SecurityAlgorithms.HmacSha256);
        }

        #region Get Claims

        private async Task<IList<Claim>> GetTokenClaimsAsync(ApplicationUser user)
        {
            List<Claim> claims =
            [
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Name, user.UserName!),
            ];

            claims.AddRange(await _userManager.GetClaimsAsync(user));
            claims.AddRange(await GetRolesClaimsAsync(user));

            return claims;
        }

        private async Task<IList<Claim>> GetRolesClaimsAsync(ApplicationUser user)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);
            IList<Claim> claims = new List<Claim>();

            foreach (string role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            return claims;
        }

        #endregion Get Claims

        #endregion Create Token

        #endregion Methods
    }
}