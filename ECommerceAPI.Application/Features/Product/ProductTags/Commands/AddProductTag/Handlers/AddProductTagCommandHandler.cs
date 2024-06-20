using AutoMapper;
using ECommerceAPI.Application.Features.Product.ProductTags.Commands.AddProductTag.DTOs;
using ECommerceAPI.Application.Features.Product.ProductTags.Commands.AddProductTag.Requests;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.ProductTags.Commands.AddProductTag.Handlers
{
    public class AddProductTagCommandHandler : ResponseHandler, IRequestHandler<AddProductTagCommandRequest, Response<AddProductTagCommandDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructor

        public AddProductTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<Response<AddProductTagCommandDTO>> Handle(AddProductTagCommandRequest request, CancellationToken cancellationToken)
        {
            var productTag = _mapper.Map<ProductTag>(request);
            await _unitOfWork.Repository<ProductTag>().AddAsync(productTag);

            var response = _mapper.Map<AddProductTagCommandDTO>(productTag);
            return Created(response);
        }

        #endregion Methods
    }
}