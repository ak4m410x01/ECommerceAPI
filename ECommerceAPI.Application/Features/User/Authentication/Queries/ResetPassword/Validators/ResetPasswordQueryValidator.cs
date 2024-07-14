using ECommerceAPI.Application.Features.User.Authentication.Queries.ResetPassword.Requests;
using ECommerceAPI.Domain.IdentityEntities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Features.User.Authentication.Queries.ResetPassword.Validators
{
    public class ResetPasswordQueryValidator : AbstractValidator<ResetPasswordQueryRequest>
    {
        #region Properties

        private readonly UserManager<ApplicationUser> _userManager;

        #endregion Properties

        #region Constructors

        public ResetPasswordQueryValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            InitializeRules();
        }

        #endregion Constructors

        #region Methods

        private void InitializeRules()
        {
            UserIdValidator();
            TokenValidator();
            PasswordValidator();
            ConfirmNewPasswordValidator();
        }

        private void UserIdValidator()
        {
            RuleFor(request => request.UserId)
                .NotEmpty().WithMessage("UserId is required field.")
                .NotNull().WithMessage("UserId must be not null.")
                .MustAsync(async (userId, cancellationToken) => (await _userManager.FindByIdAsync(userId)) != null).WithMessage("UserId doesn't exists.");
        }

        private void TokenValidator()
        {
            RuleFor(request => request.Token)
                .NotEmpty().WithMessage("Token is required field.")
                .NotNull().WithMessage("Token must be not null.");
        }

        private void PasswordValidator()
        {
            RuleFor(request => request.NewPassword)
                   .NotEmpty().WithMessage("Password is required field.")
                   .NotNull().WithMessage("Password must be not null.")
                   .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                   .Must(password => password.Any(char.IsUpper)).WithMessage("Password must contain an uppercase letter.")
                   .Must(password => password.Any(char.IsLower)).WithMessage("Password must contain a lowercase letter.")
                   .Must(password => password.Any(char.IsDigit)).WithMessage("Password must contain a digit.")
                   .Must(password => password.Any(c => !char.IsLetterOrDigit(c))).WithMessage("Password must contain a special character.");
        }

        private void ConfirmNewPasswordValidator()
        {
            RuleFor(request => request.ConfirmNewPassword)
                   .Equal(request => request.NewPassword).WithMessage("Passwords must match.");
        }

        #endregion Methods
    }
}