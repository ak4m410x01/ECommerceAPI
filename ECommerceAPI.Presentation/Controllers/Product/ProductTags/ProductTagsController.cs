using Asp.Versioning;
using ECommerceAPI.Application.Features.Product.ProductTags.Commands.AddProductTag.DTOs;
using ECommerceAPI.Application.Features.Product.ProductTags.Commands.AddProductTag.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Product.ProductTags
{
    [ApiVersion("1.0")]
    public class ProductTagsController : ProductAPIBaseController
    {
        #region Constructors

        public ProductTagsController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(AddProductTagCommandDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddProductTagAsync(AddProductTagCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }
    }
}