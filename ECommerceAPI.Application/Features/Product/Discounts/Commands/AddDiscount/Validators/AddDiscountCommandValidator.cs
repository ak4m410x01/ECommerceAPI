using ECommerceAPI.Application.Features.Product.Discounts.Commands.AddDiscount.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Product.Discounts.Commands.AddDiscount.Validators
{
    public class AddDiscountCommandValidator : AbstractValidator<AddDiscountCommandRequest>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Discount> _discountSpecification;

        #endregion Properties

        #region Constructors

        public AddDiscountCommandValidator(IUnitOfWork unitOfWork, IBaseSpecification<Discount> discountSpecification)
        {
            _unitOfWork = unitOfWork;
            _discountSpecification = discountSpecification;
            CodeValidator();
            PercentValidator();
            MaxUsesValidator();
            StartAtValidator();
            EndAtValidator();
        }

        #endregion Constructors

        #region Methods

        public void CodeValidator()
        {
            RuleFor(request => request.Code)
                .NotEmpty().WithMessage("Code can't be empty.")
                .NotNull().WithMessage("Code can't be null.")
                .MustAsync(async (code, cancellationToken) =>
                {
                    _discountSpecification.Criteria = discount => discount.Code == code;
                    return (await _unitOfWork.Repository<Discount>().FindAsNoTrackingAsync(_discountSpecification)) is null;
                }).WithMessage("Code already exists.");
        }

        public void PercentValidator()
        {
            RuleFor(request => request.Percent)
                .NotEmpty().WithMessage("Percent can't be empty.")
                .NotNull().WithMessage("Percent can't be null.")
                .GreaterThan(0).WithMessage("Percent must be greater than 0.");
        }

        public void MaxUsesValidator()
        {
            RuleFor(request => request.MaxUses)
                .NotEmpty().WithMessage("MaxUses can't be empty.")
                .NotNull().WithMessage("MaxUses can't be null.")
                .GreaterThan(0).WithMessage("MaxUses must be greater than 0.");
        }

        public void StartAtValidator()
        {
            RuleFor(request => request.StartAt)
                .NotEmpty().WithMessage("StartAt can't be empty.")
                .NotNull().WithMessage("StartAt can't be null.")
                .GreaterThan(DateTime.UtcNow).WithMessage("StartAt must be in Future.");
        }

        public void EndAtValidator()
        {
            RuleFor(request => request.EndAt)
                .NotEmpty().WithMessage("EndAt can't be empty.")
                .NotNull().WithMessage("EndAt can't be null.")
                .GreaterThan(request => request.StartAt).WithMessage("EndAt must be greater than StartAt.");
        }

        #endregion Methods
    }
}