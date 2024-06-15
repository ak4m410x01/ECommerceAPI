using Asp.Versioning;
using ECommerceAPI.Application.Features.Product.Discounts.Commands.AddDiscount.DTOs;
using ECommerceAPI.Application.Features.Product.Discounts.Commands.AddDiscount.Requests;
using ECommerceAPI.Application.Features.Product.Discounts.Queries.GetAllDiscounts.DTOs;
using ECommerceAPI.Application.Features.Product.Discounts.Queries.GetAllDiscounts.Requests;
using ECommerceAPI.Application.Features.Product.Discounts.Queries.GetDiscountById.DTOs;
using ECommerceAPI.Application.Features.Product.Discounts.Queries.GetDiscountById.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Product.Discounts
{
    [ApiVersion("1.0")]
    public class DiscountsController : ProductAPIBaseController
    {
        #region Constructors

        public DiscountsController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors

        #region Methods

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(GetAllDiscountsQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDiscountsAsync([FromQuery] GetAllDiscountsQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(AddDiscountCommandDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddDiscountAsync(AddDiscountCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpGet("{id:int}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(GetDiscountByIdQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDiscountByIdAsync([FromRoute] GetDiscountByIdQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        #endregion Methods
    }
}