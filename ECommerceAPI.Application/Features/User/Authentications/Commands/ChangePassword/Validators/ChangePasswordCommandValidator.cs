using ECommerceAPI.Application.Features.User.Authentications.Commands.ChangePassword.Requests;
using ECommerceAPI.Domain.IdentityEntities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ECommerceAPI.Application.Features.User.Authentications.Commands.ChangePassword.Validators
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
            CurrentPasswordValidator();
            NewPasswordValidator();
            ConfirmNewPasswordValidator();
        }

        #endregion Constructors

        #region Methods

        protected async Task<bool> ValidateCurrentPasswordAsync(string CurrentPassword)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext is null) return false;

            var authHeader = httpContext.Request.Headers["Authorization"].FirstOrDefault(); if
            (authHeader is null || !authHeader.StartsWith("Bearer "))
            {
                //this.AddFailure("Authorization", "Token not provided.");
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

        public void CurrentPasswordValidator()
        {
            RuleFor(request => request.NewPassword)
                   .NotEmpty().WithMessage("Password can't be empty.")
                   .NotNull().WithMessage("Password can't be null.")
                   .MustAsync(async (request, CurrentPassword, cancellationToken) => await ValidateCurrentPasswordAsync(request.CurrentPassword ?? "")).WithMessage("Current password is not valid.");
        }

        public void NewPasswordValidator()
        {
            RuleFor(request => request.NewPassword)
                   .NotEmpty().WithMessage("Password can't be empty.")
                   .NotNull().WithMessage("Password can't be null.")
                   .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                   .Must(password => password.Any(char.IsUpper)).WithMessage("Password must contain an uppercase letter.")
                   .Must(password => password.Any(char.IsLower)).WithMessage("Password must contain a lowercase letter.")
                   .Must(password => password.Any(char.IsDigit)).WithMessage("Password must contain a digit.")
                   .Must(password => password.Any(c => !char.IsLetterOrDigit(c))).WithMessage("Password must contain a special character.");
        }

        public void ConfirmNewPasswordValidator()
        {
            RuleFor(request => request.ConfirmNewPassword)
                   .NotEmpty().WithMessage("Password can't be empty.")
                   .NotNull().WithMessage("Password can't be null.")
                   .Equal(request => request.ConfirmNewPassword).WithMessage("Passwords must match.");
        }

        #endregion Methods
    }
}