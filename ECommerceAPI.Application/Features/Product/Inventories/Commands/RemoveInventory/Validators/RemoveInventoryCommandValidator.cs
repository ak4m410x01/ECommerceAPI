using ECommerceAPI.Application.Features.Product.Inventories.Commands.RemoveInventory.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Product.Inventories.Commands.RemoveInventory.Validators
{
    public class RemoveInventoryCommandValidator : AbstractValidator<RemoveInventoryCommandRequest>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Inventory> _inventorySpecification;

        #endregion Properties

        #region Constructors

        public RemoveInventoryCommandValidator(IUnitOfWork unitOfWork, IBaseSpecification<Inventory> inventorySpecification)
        {
            _unitOfWork = unitOfWork;
            _inventorySpecification = inventorySpecification;
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
                    _inventorySpecification.Criteria = inventory => inventory.Id == id && inventory.DeletedAt == null;
                    return (await _unitOfWork.Repository<Inventory>().FindAsNoTrackingAsync(_inventorySpecification)) is not null;
                }).WithMessage("Inventory doesn't exists.");
        }

        #endregion Methods
    }
}