using ECommerceAPI.Application.Features.Product.Discounts.Queries.GetDiscountById.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using FluentValidation;
using System.Threading;

namespace ECommerceAPI.Application.Features.Product.Discounts.Queries.GetDiscountById.Validators
{
    public class GetDiscountByIdQueryValidator : AbstractValidator<GetDiscountByIdQueryRequest>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Discount> _discountSpecification;

        #endregion Properties

        #region Constructors

        public GetDiscountByIdQueryValidator(IUnitOfWork unitOfWork, IBaseSpecification<Discount> discountSpecification)
        {
            _unitOfWork = unitOfWork;
            _discountSpecification = discountSpecification;
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
                    _discountSpecification.Criteria = discount => discount.Id == id;
                    return (await _unitOfWork.Repository<Discount>().FindAsNoTrackingAsync(_discountSpecification)) is not null;
                }).WithMessage("Discount doesn't exists.");
        }

        #endregion Methods
    }
}