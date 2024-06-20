using Asp.Versioning;
using ECommerceAPI.Application.Features.Product.ProductVariants.Commands.AddProductVariant.DTOs;
using ECommerceAPI.Application.Features.Product.ProductVariants.Commands.AddProductVariant.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Product.ProductVariants
{
    [ApiVersion("1.0")]
    public class ProductVariantsController : ProductAPIBaseController
    {
        #region Constructors

        public ProductVariantsController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors

        #region Methods

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(AddProductVariantCommandDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddProductVariantAsync(AddProductVariantCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        #endregion Methods
    }
}