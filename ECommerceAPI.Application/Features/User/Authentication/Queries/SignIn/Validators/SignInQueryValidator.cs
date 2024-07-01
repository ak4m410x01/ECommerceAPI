using ECommerceAPI.Application.Features.User.Authentication.Queries.SignIn.Requests;
using ECommerceAPI.Domain.IdentityEntities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Application.Features.User.Authentication.Queries.SignIn.Validators
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
            InitializeRules();
        }

        #endregion Constructors

        #region Methods

        private void InitializeRules()
        {
            EmailValidator();
            PasswordValidator();
        }

        private void EmailValidator()
        {
            RuleFor(request => request.Email)
                   .NotEmpty().WithMessage("Email is required field.")
                   .NotNull().WithMessage("Email must be not null.")
                   .Matches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$").WithMessage("Email must be valid.");
        }

        private void PasswordValidator()
        {
            RuleFor(request => request.Password)
                   .NotEmpty().WithMessage("Password is required field.")
                   .NotNull().WithMessage("Password must be not null.");
        }

        #endregion Methods
    }
}