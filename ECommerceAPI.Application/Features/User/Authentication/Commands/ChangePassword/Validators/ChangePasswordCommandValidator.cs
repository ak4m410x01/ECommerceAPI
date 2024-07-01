using ECommerceAPI.Application.Features.User.Authentication.Commands.ChangePassword.Requests;
using ECommerceAPI.Domain.IdentityEntities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ECommerceAPI.Application.Features.User.Authentication.Commands.ChangePassword.Validators
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommandRequest>
    {
        #region Properties

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion Properties

        #region Constructors

        public ChangePasswordCommandValidator(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            InitializeRules();
        }

        #endregion Constructors

        #region Methods

        private void InitializeRules()
        {
            CurrentPasswordValidator();
            NewPasswordValidator();
            ConfirmNewPasswordValidator();
        }

        private async Task<bool> ValidateCurrentPasswordAsync(string CurrentPassword)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext is null) return false;

            var authHeader = httpContext.Request.Headers["Authorization"].FirstOrDefault(); if
            (authHeader is null || !authHeader.StartsWith("Bearer "))
            {
                return false;
            }

            var token = authHeader.Substring("Bearer ".Length).Trim();
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var emailClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(emailClaim)) return false;

            var user = await _userManager.FindByEmailAsync(emailClaim);
            if (user == null) return false;

            return await _userManager.CheckPasswordAsync(user, CurrentPassword);
        }

        private void CurrentPasswordValidator()
        {
            RuleFor(request => request.CurrentPassword)
                   .NotEmpty().WithMessage("CurrentPassword is required field.")
                   .NotNull().WithMessage("CurrentPassword must be not null.")
                   .MustAsync(async (request, CurrentPassword, cancellationToken) => await ValidateCurrentPasswordAsync(request.CurrentPassword)).WithMessage("Current password is not valid.");
        }

        private void NewPasswordValidator()
        {
            RuleFor(request => request.NewPassword)
                   .NotEmpty().WithMessage("NewPassword is required field.")
                   .NotNull().WithMessage("NewPassword must be not null.")
                   .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                   .Must(password => password.Any(char.IsUpper)).WithMessage("Password must contain an uppercase letter.")
                   .Must(password => password.Any(char.IsLower)).WithMessage("Password must contain a lowercase letter.")
                   .Must(password => password.Any(char.IsDigit)).WithMessage("Password must contain a digit.")
                   .Must(password => password.Any(c => !char.IsLetterOrDigit(c))).WithMessage("Password must contain a special character.");
        }

        private void ConfirmNewPasswordValidator()
        {
            RuleFor(request => request.ConfirmNewPassword)
                   .NotEmpty().WithMessage("ConfirmNewPassword is required field.")
                   .NotNull().WithMessage("ConfirmNewPassword must be not null.")
                   .Equal(request => request.ConfirmNewPassword).WithMessage("Passwords must match.");
        }

        #endregion Methods
    }
}