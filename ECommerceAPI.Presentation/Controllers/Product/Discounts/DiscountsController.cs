using ECommerceAPI.Application.Features.Product.Discounts.Queries.GetAllDiscounts.DTOs;
using ECommerceAPI.Application.Features.Product.Discounts.Queries.GetAllDiscounts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Product.Discounts
{
    public class DiscountsController : ProductAPIBaseController
    {
        #region Constructors

        public DiscountsController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors

        #region Methods

        [HttpGet]
        [ProducesResponseType(typeof(GetAllDiscountsQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDiscountsAsync([FromQuery] GetAllDiscountsQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        #endregion Methods
    }
}