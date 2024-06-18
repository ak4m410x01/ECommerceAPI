using ECommerceAPI.Application.Features.User.Profiles.Commands.UpdateProfile.Requests;
using ECommerceAPI.Domain.Constants.Media;
using ECommerceAPI.Domain.IdentityEntities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
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
            InitializeRules();
        }

        #endregion Constructors

        #region Methods

        private void InitializeRules()
        {
            UsernameValidator();
            FirstNameValidator();
            LastNameValidator();
            PhoneNumberValidator();
            BioValidator();
            ImageValidator();
        }

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

        private void ImageValidator()
        {
            // IFormFile Image
            RuleFor(request => request.Image)
                .Cascade(CascadeMode.Stop)
                .Must(IsImageValidSize).WithMessage("Image must be less than 5 MB.")
                .Must(IsImageValidExtension).WithMessage("Image must be a valid format (jpg, jpeg, png).")
                .Must(IsImageValidMimeType).WithMessage("Image MIME type must be valid (image/jpeg, image/png).");
        }

        private bool IsImageValidSize(IFormFile? file)
        {
            const int maxSizeInBytes = 5 * 1024 * 1024; // 5 MB
            return file == null || file.Length <= maxSizeInBytes;
        }

        private bool IsImageValidExtension(IFormFile? file)
        {
            var allowedExtensions = Image.AllowedExtensions;
            var extension = Path.GetExtension(file?.FileName)?.ToLower();
            return file == null || allowedExtensions.Contains(extension);
        }

        private bool IsImageValidMimeType(IFormFile? file)
        {
            var allowedMimeTypes = Image.AllowedMimeTypes;
            return file == null || allowedMimeTypes.Contains(file.ContentType);
        }

        #endregion Methods
    }
}