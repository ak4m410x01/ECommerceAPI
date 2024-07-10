using AutoMapper;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.UpdateInventory.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.UpdateInventory.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Inventories.Commands.UpdateInventory.Handlers
{
    public class UpdateInventoryCommandHandler : ResponseHandler, IRequestHandler<UpdateInventoryCommandRequest, Response<UpdateInventoryCommandDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Inventory> _inventorySpecification;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public UpdateInventoryCommandHandler(IUnitOfWork unitOfWork, IBaseSpecification<Inventory> inventorySpecification, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _inventorySpecification = inventorySpecification;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<UpdateInventoryCommandDTO>> Handle(UpdateInventoryCommandRequest request, CancellationToken cancellationToken)
        {
            _inventorySpecification.Criteria = dsc => dsc.Id == request.Id && dsc.DeletedAt == null;
            var inventory = await _unitOfWork.Repository<Inventory>().FindAsync(_inventorySpecification);
            _mapper.Map(request, inventory);
            inventory!.ModifiedAt = DateTime.UtcNow;

            await _unitOfWork.Repository<Inventory>().UpdateAsync(inventory!);
            var response = _mapper.Map<UpdateInventoryCommandDTO>(inventory);
            return Success(response);
        }

        #endregion Methods
    }
}