using ECommerceAPI.Application.Features.Product.Inventories.Commands.UpdateInventory.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Product.Inventories.Commands.UpdateInventory.Validators
{
    public class UpdateInventoryCommandValidator : AbstractValidator<UpdateInventoryCommandRequest>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Inventory> _discountSpecification;

        #endregion Properties

        #region Constructors

        public UpdateInventoryCommandValidator(IUnitOfWork unitOfWork, IBaseSpecification<Inventory> discountSpecification)
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
            QuantityValidator();
        }

        private void IdValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.")
                .MustAsync(async (id, cancellationToken) =>
                {
                    _discountSpecification.Criteria = discount => discount.Id == id && discount.DeletedAt == null;
                    return (await _unitOfWork.Repository<Inventory>().FindAsNoTrackingAsync(_discountSpecification)) is not null;
                }).WithMessage("Inventory doesn't exists.");
        }

        private void QuantityValidator()
        {
            RuleFor(request => request.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }

        #endregion Methods
    }
}