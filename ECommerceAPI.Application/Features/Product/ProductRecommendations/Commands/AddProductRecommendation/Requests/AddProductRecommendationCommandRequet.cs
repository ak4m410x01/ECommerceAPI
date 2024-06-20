using ECommerceAPI.Application.Features.Product.ProductRecommendations.Commands.AddProductRecommendation.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.ProductRecommendations.Commands.AddProductRecommendation.Requests
{
    public class AddProductRecommendationCommandRequet : IRequest<Response<AddProductRecommendationCommandDTO>>
    {
        #region Properties

        public int ProductId { get; set; }
        public int RecommendedProductId { get; set; }

        #endregion Properties
    }
}