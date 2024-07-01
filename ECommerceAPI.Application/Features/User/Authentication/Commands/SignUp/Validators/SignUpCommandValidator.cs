using ECommerceAPI.Application.Features.User.Authentication.Commands.SignUp.Requests;
using ECommerceAPI.Domain.IdentityEntities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Features.User.Authentication.Commands.SignUp.Validators
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
            InitializeRules();
        }

        #endregion Constructors

        #region Methods

        private void InitializeRules()
        {
            EmailValidator();
            PasswordValidator();
            ConfirmPasswordValidator();
        }

        private void EmailValidator()
        {
            RuleFor(request => request.Email)
                   .NotEmpty().WithMessage("Email is required field.")
                   .NotNull().WithMessage("Email must be not null.")
                   .Matches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$").WithMessage("Email must be valid.")
                   .MustAsync(async (email, cancellationToken) => (await _userManager.FindByEmailAsync(email)) is null).WithMessage("Email already exists.");
        }

        private void PasswordValidator()
        {
            RuleFor(request => request.Password)
                   .NotEmpty().WithMessage("Password is required field.")
                   .NotNull().WithMessage("Password must be not null.")
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