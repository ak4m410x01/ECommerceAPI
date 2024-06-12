using ECommerceAPI.Application.DTOs.Authentication.Token;
using ECommerceAPI.Application.Interfaces.Services.Authentication;
using ECommerceAPI.Domain.Entities.Users;
using ECommerceAPI.Domain.IdentityEntities;
using ECommerceAPI.Shared.Helpers.JwtSettings;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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

        #region Generate Token

        public async Task<TokenDTO> GenerateTokenAsync(ApplicationUser user)
        {
            return new TokenDTO()
            {
                AccessToken = await GenerateAccessTokenAsync(user),
                RefreshToken = await GenerateRefreshTokenAsync(user)
            };
        }

        #endregion Generate Token

        #region Generate Access Token

        public async Task<AccessTokenDTO> GenerateAccessTokenAsync(ApplicationUser user)
        {
            JwtSecurityToken token = new
            (
               issuer: _jwtSettings.Issuer,
               audience: _jwtSettings.Audience,
               expires: DateTime.UtcNow.AddDays(_jwtSettings.AccessTokenExpiryDays),
               claims: await GetTokenClaimsAsync(user),
               signingCredentials: GetSigningCredentials()
            );

            return new AccessTokenDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresAt = token.ValidTo
            };
        }

        private SigningCredentials GetSigningCredentials()
        {
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_jwtSettings.Key ?? ""));
            return new(key, SecurityAlgorithms.HmacSha256);
        }

        #endregion Generate Access Token

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

        #region Generate Refresh Token

        public async Task<RefreshTokenDTO> GenerateRefreshTokenAsync(ApplicationUser user)
        {
            var refreshToken = user.RefreshTokens.FirstOrDefault(token => token.IsActive);

            if (refreshToken is null)
            {
                refreshToken = await GenerateRefreshTokenAsync();
            }

            user.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(user);

            return new RefreshTokenDTO()
            {
                Token = refreshToken.Token,
                ExpiresAt = refreshToken.ExpiresAt
            };
        }

        private async Task<RefreshToken> GenerateRefreshTokenAsync()
        {
            var randomNumber = new byte[32];

            using var generator = RandomNumberGenerator.Create();
            await Task.Run(() => generator.GetBytes(randomNumber));

            return new RefreshToken()
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiryDays),
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };
        }

        #endregion Generate Refresh Token

        #endregion Methods
    }
}