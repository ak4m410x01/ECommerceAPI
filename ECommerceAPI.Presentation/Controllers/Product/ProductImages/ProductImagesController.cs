using Asp.Versioning;
using ECommerceAPI.Application.Features.Product.ProductImages.Commands.AddProductImage.DTOs;
using ECommerceAPI.Application.Features.Product.ProductImages.Commands.AddProductImage.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Product.ProductImages
{
    [ApiVersion("1.0")]
    public class ProductImagesController : ProductAPIBaseController
    {
        #region Constructors

        public ProductImagesController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors

        #region Methods

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(AddProductImageCommandDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddProductImageAsync(AddProductImageCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        #endregion Methods
    }
}