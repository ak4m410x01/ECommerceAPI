﻿using ECommerceAPI.Application.Features.Product.Discounts.Commands.AddDiscount.Requests;
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
            InitializeRules();
        }

        #endregion Constructors

        #region Methods

        private void InitializeRules()
        {
            CodeValidator();
            PercentValidator();
            MaxUsesValidator();
            StartAtValidator();
            EndAtValidator();
        }

        private void CodeValidator()
        {
            RuleFor(request => request.Code)
                .NotEmpty().WithMessage("Code is required field.")
                .NotNull().WithMessage("Code must be not null.")
                .MustAsync(async (code, cancellationToken) =>
                {
                    _discountSpecification.Criteria = discount => discount.Code == code && discount.DeletedAt == null;
                    return (await _unitOfWork.Repository<Discount>().FindAsNoTrackingAsync(_discountSpecification)) is null;
                }).WithMessage("Code already exists.");
        }

        private void PercentValidator()
        {
            RuleFor(request => request.Percent)
                .NotEmpty().WithMessage("Percent is required field.")
                .NotNull().WithMessage("Percent must be not null.")
                .GreaterThan(0).WithMessage("Percent must be greater than 0.");
        }

        private void MaxUsesValidator()
        {
            RuleFor(request => request.MaxUses)
                .NotEmpty().WithMessage("MaxUses is required field.")
                .NotNull().WithMessage("MaxUses must be not null.")
                .GreaterThan(0).WithMessage("MaxUses must be greater than 0.");
        }

        private void StartAtValidator()
        {
            RuleFor(request => request.StartAt)
                .NotEmpty().WithMessage("StartAt is required field.")
                .NotNull().WithMessage("StartAt must be not null.")
                .GreaterThan(DateTime.UtcNow).WithMessage("StartAt must be in Future.");
        }

        private void EndAtValidator()
        {
            RuleFor(request => request.EndAt)
                .NotEmpty().WithMessage("EndAt is required field.")
                .NotNull().WithMessage("EndAt must be not null.")
                .GreaterThan(request => request.StartAt).WithMessage("EndAt must be greater than StartAt.");
        }

        #endregion Methods
    }
}