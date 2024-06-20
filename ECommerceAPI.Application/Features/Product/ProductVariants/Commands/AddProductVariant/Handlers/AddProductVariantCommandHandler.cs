using AutoMapper;
using ECommerceAPI.Application.Features.Product.ProductVariants.Commands.AddProductVariant.DTOs;
using ECommerceAPI.Application.Features.Product.ProductVariants.Commands.AddProductVariant.Requests;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.ProductVariants.Commands.AddProductVariant.Handlers
{
    public class AddProductVariantCommandHandler : ResponseHandler, IRequestHandler<AddProductVariantCommandRequest, Response<AddProductVariantCommandDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public AddProductVariantCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<AddProductVariantCommandDTO>> Handle(AddProductVariantCommandRequest request, CancellationToken cancellationToken)
        {
            var productVariant = _mapper.Map<ProductVariant>(request);
            await _unitOfWork.Repository<ProductVariant>().AddAsync(productVariant);

            var response = _mapper.Map<AddProductVariantCommandDTO>(productVariant);
            return Created(response);
        }

        #endregion Methods
    }
}