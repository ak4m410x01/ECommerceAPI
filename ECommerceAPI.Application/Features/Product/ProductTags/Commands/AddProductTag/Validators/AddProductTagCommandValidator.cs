using ECommerceAPI.Application.Features.Product.ProductTags.Commands.AddProductTag.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ProductEntity = ECommerceAPI.Domain.Entities.Products.Product;
using FluentValidation;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Features.Product.ProductTags.Commands.AddProductTag.Validators
{
    public class AddProductTagCommandValidator : AbstractValidator<AddProductTagCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<ProductEntity> _productSpecification;
        private readonly IBaseSpecification<Tag> _tagSpecification;
        private readonly IBaseSpecification<ProductTag> _productTagSpecification;

        #region Constructors

        public AddProductTagCommandValidator(IUnitOfWork unitOfWork, IBaseSpecification<ProductEntity> productSpecification, IBaseSpecification<Tag> tagSpecification, IBaseSpecification<ProductTag> productTagSpecification)
        {
            _unitOfWork = unitOfWork;
            _productSpecification = productSpecification;
            _tagSpecification = tagSpecification;
            _productTagSpecification = productTagSpecification;
            InitializeRules();
        }

        #endregion Constructors

        #region Methods

        private void InitializeRules()
        {
            ProductIdValidator();
            TagIdValidator();
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

        private void TagIdValidator()
        {
            RuleFor(request => request.TagId)
                .NotEmpty().WithMessage("TagId is required.")
                .NotNull().WithMessage("TagId must be not null.")
                .GreaterThan(0).WithMessage("TagId must be greater than 0.")
                .MustAsync(async (tagId, cancellationToken) =>
                {
                    _tagSpecification.Criteria = tag => tag.Id == tagId;
                    return await _unitOfWork.Repository<Tag>().FindAsNoTrackingAsync(_tagSpecification) is not null;
                }).WithMessage("TagId doesn't exits.")
                .MustAsync(async (request, productId, cancellationToken) =>
                 {
                     _productTagSpecification.Criteria = productTag =>
                                             productTag.ProductId == request.ProductId &&
                                             productTag.TagId == request.TagId;

                     return await _unitOfWork.Repository<ProductTag>()
                                             .FindAsNoTrackingAsync(_productTagSpecification) is null;
                 }).WithMessage("This Product Tag (ProductId, TagId) already exits.");
        }

        #endregion Methods
    }
}