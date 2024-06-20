using ECommerceAPI.Application.Features.Product.ProductVariants.Commands.AddProductVariant.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ProductEntity = ECommerceAPI.Domain.Entities.Products.Product;
using FluentValidation;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Features.Product.ProductVariants.Commands.AddProductVariant.Validators
{
    public class AddProductVariantCommandValidator : AbstractValidator<AddProductVariantCommandRequest>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<ProductEntity> _productSpecification;
        private readonly IBaseSpecification<ProductVariant> _productVariantSpecification;

        #endregion Properties

        #region Constructors

        public AddProductVariantCommandValidator(IUnitOfWork unitOfWork, IBaseSpecification<ProductEntity> productSpecification, IBaseSpecification<ProductVariant> productVariantSpecification)
        {
            _unitOfWork = unitOfWork;
            _productSpecification = productSpecification;
            _productVariantSpecification = productVariantSpecification;
            InitializeRules();
        }

        #endregion Constructors

        #region Methods

        private void InitializeRules()
        {
            ProductIdValidator();
            NameValidator();
            ValueValidator();
        }

        private void ProductIdValidator()
        {
            RuleFor(request => request.ProductId)
                .NotEmpty().WithMessage("ProductId is required.")
                .NotNull().WithMessage("ProductId must be not null.")
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.")
                .MustAsync(async (productId, cancellationToken) =>
                {
                    _productSpecification.Criteria = product => product.Id == productId;
                    return await _unitOfWork.Repository<ProductEntity>().FindAsNoTrackingAsync(_productSpecification) is not null;
                }).WithMessage("ProductId doesn't exits.");
        }

        private void NameValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty().WithMessage("Name is required.")
                .NotNull().WithMessage("Name must be not null.")
                .MustAsync(async (request, name, cancellationToken) =>
                {
                    _productVariantSpecification.Criteria = variant => variant.Name == request.Name && variant.ProductId == request.ProductId;
                    return await _unitOfWork.Repository<ProductVariant>().FindAsNoTrackingAsync(_productVariantSpecification) is null;
                }).WithMessage("Name already exits.");
        }

        private void ValueValidator()
        {
            RuleFor(request => request.Value)
                .NotEmpty().WithMessage("Value is required.")
                .NotNull().WithMessage("Value must be not null.");
        }

        #endregion Methods
    }
}