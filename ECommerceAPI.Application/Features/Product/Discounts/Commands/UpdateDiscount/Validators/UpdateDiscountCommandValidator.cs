using ECommerceAPI.Application.Features.Product.Discounts.Commands.UpdateDiscount.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Product.Discounts.Commands.UpdateDiscount.Validators
{
    public class UpdateDiscountCommandValidator : AbstractValidator<UpdateDiscountCommandRequest>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Discount> _discountSpecification;

        #endregion Properties

        #region Constructors

        public UpdateDiscountCommandValidator(IUnitOfWork unitOfWork, IBaseSpecification<Discount> discountSpecification)
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
            CodeValidator();
            PercentValidator();
            MaxUsesValidator();
            StartAtValidator();
            EndAtValidator();
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

        private void CodeValidator()
        {
            RuleFor(request => request.Code)
                .MustAsync(async (request, code, cancellationToken) =>
                {
                    _discountSpecification.Criteria = discount => discount.Id != request.Id && discount.Code == request.Code && discount.DeletedAt == null;
                    return (await _unitOfWork.Repository<Discount>().FindAsNoTrackingAsync(_discountSpecification)) is null;
                }).WithMessage("Code already exists.");
        }

        private void PercentValidator()
        {
            RuleFor(request => request.Percent)
                .GreaterThan(0).WithMessage("Percent must be greater than 0.");
        }

        private void MaxUsesValidator()
        {
            RuleFor(request => request.MaxUses)
                .GreaterThan(0).WithMessage("MaxUses must be greater than 0.");
        }

        private void StartAtValidator()
        {
            RuleFor(request => request.StartAt)
                .GreaterThan(DateTime.UtcNow).WithMessage("StartAt must be in Future.");
        }

        private void EndAtValidator()
        {
            RuleFor(request => request.EndAt)
                .GreaterThan(request => request.StartAt).WithMessage("EndAt must be greater than StartAt.");
        }

        #endregion Methods
    }
}