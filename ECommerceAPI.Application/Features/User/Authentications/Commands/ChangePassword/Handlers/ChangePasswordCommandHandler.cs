using ECommerceAPI.Application.Features.User.Authentications.Commands.ChangePassword.DTOs;
using ECommerceAPI.Application.Features.User.Authentications.Commands.ChangePassword.Requests;
using ECommerceAPI.Domain.IdentityEntities;
using ECommerceAPI.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ECommerceAPI.Application.Features.User.Authentications.Commands.ChangePassword.Handlers
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
            var httpContext = _httpContextAccessor.HttpContext;

            var authHeader = httpContext?.Request.Headers["Authorization"].FirstOrDefault();

            var token = authHeader?.Substring("Bearer ".Length).Trim();
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var emailClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;

            var user = await _userManager.FindByEmailAsync(emailClaim ?? "");

            return user!;
        }

        public async Task<Response<ChangePasswordCommandDTO>> Handle(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await GetSignInUserAsync();
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword!, request.NewPassword!);

            if (!result.Succeeded)
            {
                return BadRequest<ChangePasswordCommandDTO>("Password UnChanged.");
            }

            return Success<ChangePasswordCommandDTO>("Password Changed Successfully.");
        }

        #endregion Methods
    }
}