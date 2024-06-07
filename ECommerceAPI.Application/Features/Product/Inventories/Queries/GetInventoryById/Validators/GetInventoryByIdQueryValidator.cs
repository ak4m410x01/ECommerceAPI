using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetInventoryById.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Product.Inventories.Queries.GetInventoryById.Validators
{
    public class GetInventoryByIdQueryValidator : AbstractValidator<GetInventoryByIdQueryRequest>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Inventory> _inventorySpecification;

        #endregion Properties

        #region Constructors

        public GetInventoryByIdQueryValidator(IUnitOfWork unitOfWork, IBaseSpecification<Inventory> inventorySpecification)
        {
            _unitOfWork = unitOfWork;
            _inventorySpecification = inventorySpecification;
            IdValidator();
        }

        #endregion Constructors

        #region Methods

        public void IdValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(0).WithMessage("Id must greater than 1.")
                .MustAsync(async (id, cancellationToken) =>
                {
                    _inventorySpecification.Criteria = inventory => inventory.Id == id;
                    return (await _unitOfWork.Repository<Inventory>().FindAsNoTrackingAsync(_inventorySpecification)) is not null;
                }).WithMessage("Inventory doesn't exists.");
        }

        #endregion Methods
    }
}