using ECommerceAPI.Application.Interfaces.Services.Authentication;
using ECommerceAPI.Domain.IdentityEntities;
using ECommerceAPI.Shared.Helpers.JwtSettings;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerceAPI.Infrastructure.Services.Authentication
{
    public class TokenService : ITokenService
    {
        #region Properties

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly JwtSettings _jwtSettings;

        #endregion Properties

        #region Constructors

        public TokenService(UserManager<ApplicationUser> userManager, JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }

        #endregion Constructors

        #region Methods

        #region Create Token

        public async Task<(string value, DateTime validTo)> CreateTokenAsync(ApplicationUser user)
        {
            JwtSecurityToken token = new
            (
               issuer: _jwtSettings.Issuer,
               audience: _jwtSettings.Audience,
               expires: DateTime.UtcNow.AddDays(double.Parse(_jwtSettings.Key ?? "0")),
               claims: await GetTokenClaimsAsync(user),
               signingCredentials: GetSigningCredentials()
            );

            return (new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo);
        }

        private SigningCredentials GetSigningCredentials()
        {
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_jwtSettings.Key ?? ""));
            return new(key, SecurityAlgorithms.HmacSha256);
        }

        #region Get Claims

        private async Task<IList<Claim>> GetTokenClaimsAsync(ApplicationUser user)
        {
            List<Claim> claims =
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id!),
                new Claim(ClaimTypes.Email, user.Email!)
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