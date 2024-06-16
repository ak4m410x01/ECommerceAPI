using ECommerceAPI.Application.Features.User.Profiles.Commands.UpdateProfile.Requests;
using ECommerceAPI.Domain.IdentityEntities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Features.User.Profiles.Commands.UpdateProfile.Validators
{
    public class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommandRequest>
    {
        #region Properties

        private readonly UserManager<ApplicationUser> _userManager;

        #endregion Properties

        #region Constructors

        public UpdateProfileCommandValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            UsernameValidator();
            FirstNameValidator();
            LastNameValidator();
            PhoneNumberValidator();
            BioValidator();
        }

        #endregion Constructors

        #region Methods

        private void UsernameValidator()
        {
            RuleFor(request => request.Username)
             .MustAsync(async (username, cancellationToken) => username == null || await _userManager.FindByNameAsync(username) == null).WithMessage("Username already exists.");
        }

        private void FirstNameValidator()
        {
            RuleFor(request => request.FirstName)
                .MaximumLength(100).WithMessage("FirstName maximum length must be 100.");
        }

        private void LastNameValidator()
        {
            RuleFor(request => request.LastName)
                .MaximumLength(100).WithMessage("LastName maximum length must be 100.");
        }

        private void PhoneNumberValidator()
        {
            RuleFor(request => request.PhoneNumber)
                .MaximumLength(30).WithMessage("PhoneNumber maximum length must be 30.");
        }

        private void BioValidator()
        {
            RuleFor(request => request.Bio)
                .MaximumLength(1000).WithMessage("Bio maximum length must be 100.");
        }

        #endregion Methods
    }
}