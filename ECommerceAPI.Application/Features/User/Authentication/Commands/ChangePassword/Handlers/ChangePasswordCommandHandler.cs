using ECommerceAPI.Application.Features.User.Authentication.Commands.ChangePassword.DTOs;
using ECommerceAPI.Application.Features.User.Authentication.Commands.ChangePassword.Requests;
using ECommerceAPI.Domain.IdentityEntities;
using ECommerceAPI.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ECommerceAPI.Application.Features.User.Authentication.Commands.ChangePassword.Handlers
{
    public class ChangePasswordCommandHandler : ResponseHandler, IRequestHandler<ChangePasswordCommandRequest, Response<ChangePasswordCommandDTO>>
    {
        #region Properties

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion Properties

        #region Constructors

        public ChangePasswordCommandHandler(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion Constructors

        #region Methods

        protected async Task<ApplicationUser> GetSignInUserAsync()
        {
            // Get Token From Request Authorization Header
            var authorizationHeader = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault();
            var token = authorizationHeader!.Substring($"{JwtBearerDefaults.AuthenticationScheme} ".Length).Trim();
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            var emailClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(emailClaim ?? string.Empty);
            return user!;
        }

        public async Task<Response<ChangePasswordCommandDTO>> Handle(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await GetSignInUserAsync();
            await _userManager.ChangePasswordAsync(user, request.CurrentPassword!, request.NewPassword!);
            return Success<ChangePasswordCommandDTO>("Password Changed Successfully.");
        }

        #endregion Methods
    }
}