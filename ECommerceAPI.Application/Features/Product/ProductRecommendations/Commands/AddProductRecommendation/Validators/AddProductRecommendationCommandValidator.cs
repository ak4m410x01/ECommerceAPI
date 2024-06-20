using ECommerceAPI.Application.Features.Product.ProductRecommendations.Commands.AddProductRecommendation.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using FluentValidation;
using ProductEntity = ECommerceAPI.Domain.Entities.Products.Product;

namespace ECommerceAPI.Application.Features.Product.ProductRecommendations.Commands.AddProductRecommendation.Validators
{
    public class AddProductRecommendationCommandValidator : AbstractValidator<AddProductRecommendationCommandRequet>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<ProductEntity> _productSpecification;
        private readonly IBaseSpecification<ProductRecommendation> _productRecommendationSpecification;

        #endregion Properties

        #region Constructors

        public AddProductRecommendationCommandValidator(IUnitOfWork unitOfWork, IBaseSpecification<ProductEntity> productSpecification, IBaseSpecification<ProductRecommendation> productRecommendationSpecification)
        {
            _unitOfWork = unitOfWork;
            _productSpecification = productSpecification;
            _productRecommendationSpecification = productRecommendationSpecification;
            InitializeRules();
        }

        #endregion Constructors

        #region Methods

        private void InitializeRules()
        {
            ProductIdValidator();
            RecommendedProductId();
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

        private void RecommendedProductId()
        {
            RuleFor(request => request.RecommendedProductId)
                .NotEmpty().WithMessage("RecommendedProductId is required.")
                .NotNull().WithMessage("RecommendedProductId must be not null.")
                .GreaterThan(0).WithMessage("RecommendedProductId must be greater than 0.")
                .NotEqual(request => request.ProductId).WithMessage("RecommendedProductId and ProductId must be not same.")
                .MustAsync(async (productId, cancellationToken) =>
                {
                    _productSpecification.Criteria = product => product.Id == productId;
                    return await _unitOfWork.Repository<ProductEntity>().FindAsNoTrackingAsync(_productSpecification) is not null;
                }).WithMessage("RecommendedProductId doesn't exits.")
            .MustAsync(async (request, productId, cancellationToken) =>
            {
                _productRecommendationSpecification.Criteria = product =>
                                        product.ProductId == request.ProductId &&
                                        product.RecommendedProductId == request.RecommendedProductId;

                return await _unitOfWork.Repository<ProductRecommendation>()
                                        .FindAsNoTrackingAsync(_productRecommendationSpecification) is null;
            }).WithMessage("This Product Recommendation (RecommendedProductId, ProductId) already exits.");

            #endregion Methods
        }
    }
}