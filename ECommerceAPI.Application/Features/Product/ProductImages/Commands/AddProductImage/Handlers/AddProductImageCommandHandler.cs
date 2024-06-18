using AutoMapper;
using ECommerceAPI.Application.Features.Product.ProductImages.Commands.AddProductImage.DTOs;
using ECommerceAPI.Application.Features.Product.ProductImages.Commands.AddProductImage.Requests;
using ECommerceAPI.Application.Interfaces.Services.Media;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.ProductImages.Commands.AddProductImage.Handlers
{
    public class AddProductImageCommandHandler : ResponseHandler, IRequestHandler<AddProductImageCommandRequest, Response<AddProductImageCommandDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaService _mediaService;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public AddProductImageCommandHandler(IUnitOfWork unitOfWork, IMediaService mediaService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mediaService = mediaService;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<AddProductImageCommandDTO>> Handle(AddProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            var productImage = _mapper.Map<ProductImage>(request);
            var url = await _mediaService.SaveAsync(request.Image, "Images", "Products");
            productImage.Url = url;

            await _unitOfWork.Repository<ProductImage>().AddAsync(productImage);

            var response = _mapper.Map<AddProductImageCommandDTO>(productImage);
            return Created(response);
        }

        #endregion Methods
    }
}