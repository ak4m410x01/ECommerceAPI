using ECommerceAPI.Application.Features.Product.Discounts.Commands.RemoveDiscount.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Product.Discounts.Commands.RemoveDiscount.Validators
{
    public class RemoveDiscountCommandValidator : AbstractValidator<RemoveDiscountCommandRequest>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Discount> _discountSpecification;

        #endregion Properties

        #region Constructors

        public RemoveDiscountCommandValidator(IUnitOfWork unitOfWork, IBaseSpecification<Discount> discountSpecification)
        {
            _unitOfWork = unitOfWork;
            _discountSpecification = discountSpecification;
            InitializeRules();
        }

        #endregion Constructors

        #region Methods

        private void InitializeRules()
        {
            IdValidator();
        }

        private void IdValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.")
                .MustAsync(async (id, cancellationToken) =>
                {
                    _discountSpecification.Criteria = discount => discount.Id == id && discount.DeletedAt == null;
                    return (await _unitOfWork.Repository<Discount>().FindAsNoTrackingAsync(_discountSpecification)) is not null;
                }).WithMessage("Discount doesn't exists.");
        }

        #endregion Methods
    }
}