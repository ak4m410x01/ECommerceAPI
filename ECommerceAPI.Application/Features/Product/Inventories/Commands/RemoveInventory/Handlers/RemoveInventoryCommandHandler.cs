using ECommerceAPI.Application.Features.Product.Inventories.Commands.RemoveInventory.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.RemoveInventory.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Inventories.Commands.RemoveInventory.Handlers
{
    public class RemoveInventoryCommandHandler : ResponseHandler, IRequestHandler<RemoveInventoryCommandRequest, Response<RemoveInventoryCommandDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Inventory> _inventorySpecification;

        #endregion Properties

        #region Constructors

        public RemoveInventoryCommandHandler(IUnitOfWork unitOfWork, IBaseSpecification<Inventory> inventorySpecification)
        {
            _unitOfWork = unitOfWork;
            _inventorySpecification = inventorySpecification;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<RemoveInventoryCommandDTO>> Handle(RemoveInventoryCommandRequest request, CancellationToken cancellationToken)
        {
            _inventorySpecification.Criteria = inventory => inventory.Id == request.Id && inventory.DeletedAt == null;
            var inventory = await _unitOfWork.Repository<Inventory>().FindAsync(_inventorySpecification);

            await _unitOfWork.Repository<Inventory>().RemoveAsync(inventory!);
            return Removed<RemoveInventoryCommandDTO>();
        }

        #endregion Methods
    }
}