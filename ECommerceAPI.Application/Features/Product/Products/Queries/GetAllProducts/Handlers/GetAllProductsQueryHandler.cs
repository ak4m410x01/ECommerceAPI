using AutoMapper;
using ECommerceAPI.Application.Extensions.Responses;
using ECommerceAPI.Application.Features.Product.Products.Queries.GetAllProducts.DTOs;
using ECommerceAPI.Application.Features.Product.Products.Queries.GetAllProducts.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Shared.Responses;
using MediatR;
using ProductEntity = ECommerceAPI.Domain.Entities.Products.Product;

namespace ECommerceAPI.Application.Features.Product.Products.Queries.GetAllProducts.Handlers
{
    public class GetAllProductsQueryHandler : ResponseHandler, IRequestHandler<GetAllProductsQueryRequest, PaginatedResponse<GetAllProductsQueryDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBaseSpecification<ProductEntity> _productSpecification;

        #endregion Properties

        #region Constructors

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IBaseSpecification<ProductEntity> productSpecification)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productSpecification = productSpecification;
        }

        #endregion Constructors

        #region Methods

        public async Task<PaginatedResponse<GetAllProductsQueryDTO>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.Repository<ProductEntity>().GetAllAsNoTrackingAsync(_productSpecification);
            var data = _mapper.ProjectTo<GetAllProductsQueryDTO>(products);

            var paginatedData = await data.ToPaginatedQueryableAsync(request.PageNumber, request.PageSize);
            return paginatedData;
        }

        #endregion Methods
    }
}