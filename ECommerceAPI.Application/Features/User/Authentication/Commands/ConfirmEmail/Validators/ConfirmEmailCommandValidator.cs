using ECommerceAPI.Application.Features.User.Authentication.Commands.ConfirmEmail.Requests;
using FluentValidation;

namespace ECommerceAPI.Application.Features.User.Authentication.Commands.ConfirmEmail.Validators
{
    public class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommandRequest>
    {
        #region Constructors

        public ConfirmEmailCommandValidator()
        {
            InitializeRules();
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
                .NotNull().WithMessage("UserId must be not null.");
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