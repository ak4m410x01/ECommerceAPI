using ECommerceAPI.Application.Features.User.Authentication.Queries.ForgetPassword.Requests;
using ECommerceAPI.Domain.IdentityEntities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Features.User.Authentication.Queries.ForgetPassword.Validators
{
    public class ForgetPasswordQueryValidator : AbstractValidator<ForgetPasswordQueryRequest>
    {
        #region Properties

        private readonly UserManager<ApplicationUser> _userManager;

        #endregion Properties

        #region Constructors

        public ForgetPasswordQueryValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            InitializeRules();
        }

        #endregion Constructors

        #region Methods

        private void InitializeRules()
        {
            EmailValidator();
        }

        private void EmailValidator()
        {
            RuleFor(request => request.Email)
                   .NotEmpty().WithMessage("Email is required field.")
                   .NotNull().WithMessage("Email must be not null.")
                   .Matches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$").WithMessage("Email must be valid.")
                   .MustAsync(async (email, cancellationToken) => (await _userManager.FindByEmailAsync(email)) != null).WithMessage("Email doesn't exists.");
        }

        #endregion Methods
    }
}