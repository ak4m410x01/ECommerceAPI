using ECommerceAPI.Application.Features.User.Authentication.Commands.ConfirmEmail.Requests;
using ECommerceAPI.Domain.IdentityEntities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Features.User.Authentication.Commands.ConfirmEmail.Validators
{
    public class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommandRequest>
    {
        #region Properties

        private readonly UserManager<ApplicationUser> _userManager;

        #endregion Properties

        #region Constructors

        public ConfirmEmailCommandValidator(UserManager<ApplicationUser> userManager)
        {
            InitializeRules();
            _userManager = userManager;
        }

        #endregion Constructors

        #region Methods

        private void InitializeRules()
        {
            UserIdValidator();
            TokenValidator();
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

        #endregion Methods
    }
}