using AutoMapper;
using ECommerceAPI.Application.Features.Product.Products.Commands.AddProduct.DTOs;
using ECommerceAPI.Application.Features.Product.Products.Commands.AddProduct.Requests;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Shared.Responses;
using MediatR;
using ProductEntity = ECommerceAPI.Domain.Entities.Products.Product;

namespace ECommerceAPI.Application.Features.Product.Products.Commands.AddProduct.Handlers
{
    public class AddProductCommandHandler : ResponseHandler, IRequestHandler<AddProductCommandRequest, Response<AddProductCommandDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public AddProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<AddProductCommandDTO>> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductEntity>(request);
            await _unitOfWork.Repository<ProductEntity>().AddAsync(product);

            var response = _mapper.Map<AddProductCommandDTO>(product);
            return Created(response);
        }

        #endregion Methods
    }
}