using ECommerceAPI.Application.Features.Product.ProductImages.Commands.AddProductImage.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Constants.Media;
using ProductEntity = ECommerceAPI.Domain.Entities.Products.Product;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Application.Features.Product.ProductImages.Commands.AddProductImage.Validators
{
    public class AddProductImageCommandValidator : AbstractValidator<AddProductImageCommandRequest>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<ProductEntity> _productSpecification;

        #endregion Properties

        #region Constructors

        public AddProductImageCommandValidator(IUnitOfWork unitOfWork, IBaseSpecification<ProductEntity> productSpecification)
        {
            _unitOfWork = unitOfWork;
            _productSpecification = productSpecification;
            InitializeRules();
        }

        #endregion Constructors

        #region Methods

        private void InitializeRules()
        {
            ProductIdValidator();
            ImageValidator();
        }

        private void ProductIdValidator()
        {
            RuleFor(request => request.ProductId)
                .NotEmpty().WithMessage("ProductId can't be empty.")
                .NotNull().WithMessage("ProductId can't be null.")
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.")
                .MustAsync(async (productId, cancellationToken) =>
                {
                    _productSpecification.Criteria = product => product.Id == productId;
                    return (await _unitOfWork.Repository<ProductEntity>().FindAsNoTrackingAsync(_productSpecification)) is not null;
                }).WithMessage("ProductId doesn't exists."); ;
        }

        private void ImageValidator()
        {
            // IFormFile Image
            RuleFor(request => request.Image)
                .NotEmpty().WithMessage("Image can't be empty.")
                .NotNull().WithMessage("Image can't be null.")
                .Must(IsImageValidSize).WithMessage("Image must be less than 5 MB.")
                .Must(IsImageValidExtension).WithMessage("Image must be a valid format (jpg, jpeg, png).")
                .Must(IsImageValidMimeType).WithMessage("Image MIME type must be valid (image/jpeg, image/png).");
        }

        private bool IsImageValidSize(IFormFile image)
        {
            const int maxSizeInBytes = 5 * 1024 * 1024; // 5 MB
            return image.Length <= maxSizeInBytes;
        }

        private bool IsImageValidExtension(IFormFile image)
        {
            var extension = Path.GetExtension(image.FileName).ToLower();
            return Image.AllowedExtensions.Contains(extension);
        }

        private bool IsImageValidMimeType(IFormFile image)
        {
            return Image.AllowedMimeTypes.Contains(image.ContentType);
        }

        #endregion Methods
    }
}