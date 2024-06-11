using ECommerceAPI.Application.Features.Product.Products.Queries.GetProductById.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using FluentValidation;
using ProductEntity = ECommerceAPI.Domain.Entities.Products.Product;

namespace ECommerceAPI.Application.Features.Product.Products.Queries.GetProductById.Validators
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQueryRequest>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<ProductEntity> _productSpecification;

        #endregion Properties

        #region Constructors

        public GetProductByIdQueryValidator(IUnitOfWork unitOfWork, IBaseSpecification<ProductEntity> productSpecification)
        {
            _unitOfWork = unitOfWork;
            _productSpecification = productSpecification;
            IdValidator();
        }

        #endregion Constructors

        #region Methods

        public void IdValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 1.")
                .MustAsync(async (id, cancellationToken) =>
                {
                    _productSpecification.Criteria = discount => discount.Id == id;
                    return (await _unitOfWork.Repository<ProductEntity>().FindAsNoTrackingAsync(_productSpecification)) is not null;
                }).WithMessage("Product doesn't exists.");
        }

        #endregion Methods
    }
}