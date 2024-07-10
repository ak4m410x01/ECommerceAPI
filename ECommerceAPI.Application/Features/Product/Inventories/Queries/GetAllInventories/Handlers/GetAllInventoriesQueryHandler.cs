using AutoMapper;
using ECommerceAPI.Application.Extensions.Responses;
using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetAllInventories.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetAllInventories.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Inventories.Queries.GetAllInventories.Handlers
{
    public class GetAllInventoriesQueryHandler : ResponseHandler, IRequestHandler<GetAllInventoriesQueryRequest, PaginatedResponse<GetAllInventoriesQueryDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBaseSpecification<Inventory> _inventorySpecification;

        #endregion Properties

        #region Constructors

        public GetAllInventoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IBaseSpecification<Inventory> inventorySpecification)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _inventorySpecification = inventorySpecification;
        }

        #endregion Constructors

        #region Methods

        public async Task<PaginatedResponse<GetAllInventoriesQueryDTO>> Handle(GetAllInventoriesQueryRequest request, CancellationToken cancellationToken)
        {
            _inventorySpecification.Criteria = inventory => inventory.DeletedAt == null;
            var inventories = await _unitOfWork.Repository<Inventory>().GetAllAsNoTrackingAsync(_inventorySpecification);
            var data = _mapper.ProjectTo<GetAllInventoriesQueryDTO>(inventories);

            var paginatedData = await data.ToPaginatedQueryableAsync(request.PageNumber, request.PageSize);
            return paginatedData;
        }

        #endregion Methods
    }
}