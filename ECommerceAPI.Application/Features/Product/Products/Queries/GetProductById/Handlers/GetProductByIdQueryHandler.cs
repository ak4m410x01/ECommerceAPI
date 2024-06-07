using AutoMapper;
using ECommerceAPI.Application.Features.Product.Products.Queries.GetProductById.DTOs;
using ECommerceAPI.Application.Features.Product.Products.Queries.GetProductById.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Shared.Responses;
using MediatR;
using ProductEntity = ECommerceAPI.Domain.Entities.Products.Product;

namespace ECommerceAPI.Application.Features.Product.Products.Queries.GetProductById.Handlers
{
    public class GetProductByIdQueryHandler : ResponseHandler, IRequestHandler<GetProductByIdQueryRequest, Response<GetProductByIdQueryDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<ProductEntity> _productSpecification;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IBaseSpecification<ProductEntity> productSpecification, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _productSpecification = productSpecification;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<GetProductByIdQueryDTO>> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            _productSpecification.Criteria = product => product.Id == request.Id;
            var product = await _unitOfWork.Repository<ProductEntity>().FindAsNoTrackingAsync(_productSpecification);
            var data = _mapper.Map<GetProductByIdQueryDTO>(product);
            return Success(data);
        }

        #endregion Methods
    }
}