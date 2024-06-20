using AutoMapper;
using ECommerceAPI.Application.Features.Product.ProductRecommendations.Commands.AddProductRecommendation.DTOs;
using ECommerceAPI.Application.Features.Product.ProductRecommendations.Commands.AddProductRecommendation.Requests;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.ProductRecommendations.Commands.AddProductRecommendation.Handlers
{
    public class AddProductRecommendationCommandHandler : ResponseHandler, IRequestHandler<AddProductRecommendationCommandRequet, Response<AddProductRecommendationCommandDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public AddProductRecommendationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<AddProductRecommendationCommandDTO>> Handle(AddProductRecommendationCommandRequet request, CancellationToken cancellationToken)
        {
            var productRecommendation = _mapper.Map<ProductRecommendation>(request);
            await _unitOfWork.Repository<ProductRecommendation>().AddAsync(productRecommendation);

            var response = _mapper.Map<AddProductRecommendationCommandDTO>(productRecommendation);
            return Created(response);
        }

        #endregion Methods
    }
}