using ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.Requests;
using ECommerceAPI.Domain.IdentityEntities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.Validators
{
    public class SignInQueryValidator : AbstractValidator<SignInQueryRequest>
    {
        #region Properties

        private readonly UserManager<ApplicationUser> _userManager;

        #endregion Properties

        #region Constructors

        public SignInQueryValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            EmailValidator();
            PasswordValidator();
        }

        #endregion Constructors

        #region Methods

        public void EmailValidator()
        {
            RuleFor(request => request.Email)
                   .NotEmpty().WithMessage("Email can't be empty.")
                   .NotNull().WithMessage("Email can't be null.")
                   .Matches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$").WithMessage("Email must be valid.");
        }

        public void PasswordValidator()
        {
            RuleFor(request => request.Password)
                   .NotEmpty().WithMessage("Password can't be empty.")
                   .NotNull().WithMessage("Password can't be null.");
        }

        #endregion Methods
    }
}