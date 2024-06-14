using ECommerceAPI.Application.Features.User.Authentications.Commands.SignUp.Requests;
using ECommerceAPI.Domain.IdentityEntities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Features.User.Authentications.Commands.SignUp.Validators
{
    public class SignUpCommandValidator : AbstractValidator<SignUpCommandRequest>
    {
        #region Properties

        public readonly UserManager<ApplicationUser> _userManager;

        #endregion Properties

        #region Constructors

        public SignUpCommandValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            EmailValidator();
            PasswordValidator();
            ConfirmPasswordValidator();
        }

        #endregion Constructors

        #region Methods

        private void EmailValidator()
        {
            RuleFor(request => request.Email)
                   .NotEmpty().WithMessage("Email can't be empty.")
                   .NotNull().WithMessage("Email can't be null.")
                   .Matches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$").WithMessage("Email must be valid.")
                   .MustAsync(async (email, cancellationToken) => (await _userManager.FindByEmailAsync(email)) is null).WithMessage("Email already exists.");
        }

        private void PasswordValidator()
        {
            RuleFor(request => request.Password)
                   .NotEmpty().WithMessage("Password can't be empty.")
                   .NotNull().WithMessage("Password can't be null.")
                   .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                   .Must(password => password.Any(char.IsUpper)).WithMessage("Password must contain an uppercase letter.")
                   .Must(password => password.Any(char.IsLower)).WithMessage("Password must contain a lowercase letter.")
                   .Must(password => password.Any(char.IsDigit)).WithMessage("Password must contain a digit.")
                   .Must(password => password.Any(c => !char.IsLetterOrDigit(c))).WithMessage("Password must contain a special character.");
        }

        private void ConfirmPasswordValidator()
        {
            RuleFor(request => request.ConfirmPassword)
                   .Equal(request => request.Password).WithMessage("Passwords must match.");
        }

        #endregion Methods
    }
}