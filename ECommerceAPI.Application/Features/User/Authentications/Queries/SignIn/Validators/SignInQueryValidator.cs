using ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.Requests;
using FluentValidation;

namespace ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.Validators
{
    public class SignInQueryValidator : AbstractValidator<SignInQueryRequest>
    {
        public SignInQueryValidator()
        {
            EmailValidator();
            PasswordValidator();
        }

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
    }
}