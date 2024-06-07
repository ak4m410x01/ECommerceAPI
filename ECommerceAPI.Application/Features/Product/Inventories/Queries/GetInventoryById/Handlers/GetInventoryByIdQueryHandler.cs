using AutoMapper;
using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetInventoryById.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetInventoryById.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Inventories.Queries.GetInventoryById.Handlers
{
    internal class GetInventoryByIdQueryHandler : ResponseHandler, IRequestHandler<GetInventoryByIdQueryRequest, Response<GetInventoryByIdQueryDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Inventory> _inventorySpecification;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public GetInventoryByIdQueryHandler(IUnitOfWork unitOfWork, IBaseSpecification<Inventory> inventorySpecification, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _inventorySpecification = inventorySpecification;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<GetInventoryByIdQueryDTO>> Handle(GetInventoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            _inventorySpecification.Criteria = inventory => inventory.Id == request.Id;
            var inventory = await _unitOfWork.Repository<Inventory>().FindAsNoTrackingAsync(_inventorySpecification);

            var data = _mapper.Map<GetInventoryByIdQueryDTO>(inventory);
            return Success(data);
        }

        #endregion Methods
    }
}