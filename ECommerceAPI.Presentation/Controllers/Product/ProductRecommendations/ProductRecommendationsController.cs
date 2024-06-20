using Asp.Versioning;
using ECommerceAPI.Application.Features.Product.ProductRecommendations.Commands.AddProductRecommendation.DTOs;
using ECommerceAPI.Application.Features.Product.ProductRecommendations.Commands.AddProductRecommendation.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Product.ProductRecommendations
{
    [ApiVersion("1.0")]
    public class ProductRecommendationsController : ProductAPIBaseController
    {
        #region Constructors

        public ProductRecommendationsController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors

        #region Methods

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(AddProductRecommendationCommandDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddProductRecommendationAsync(AddProductRecommendationCommandRequet request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        #endregion Methods
    }
}