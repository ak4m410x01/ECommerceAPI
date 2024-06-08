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
            UserNameValidator();
            PasswordValidator();
            ConfirmPasswordValidator();
        }

        #endregion Constructors

        #region Methods

        public void EmailValidator()
        {
            RuleFor(request => request.Email)
                   .NotEmpty().WithMessage("Email can't be empty.")
                   .NotNull().WithMessage("Email can't be null.")
                   .Matches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$").WithMessage("Email must be valid.")
                   .MustAsync(async (email, cancellationToken) => (await _userManager.FindByEmailAsync(email)) is null).WithMessage("Email already exists.");
        }

        public void UserNameValidator()
        {
            RuleFor(request => request.UserName)
                   .NotEmpty().WithMessage("UserName can't be empty.")
                   .NotNull().WithMessage("UserName can't be null.")
                   .MustAsync(async (username, cancellationToken) => (await _userManager.FindByNameAsync(username)) is null).WithMessage("UserName already exists.");
        }

        public void PasswordValidator()
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

        public void ConfirmPasswordValidator()
        {
            RuleFor(request => request.ConfirmPassword)
                   .NotEmpty().WithMessage("ConfirmPassword can't be empty.")
                   .NotNull().WithMessage("ConfirmPassword can't be null.")
                   .Equal(request => request.Password).WithMessage("Passwords must match.");
        }

        #endregion Methods
    }
}