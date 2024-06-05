using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetAllInventories.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetAllInventories.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Product.Inventories
{
    public class InventoriesController : ProductAPIBaseController
    {
        #region Constructors

        public InventoriesController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors

        #region Methods

        [HttpGet]
        [ProducesResponseType(typeof(GetAllInventoriesQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllInventoriesQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        #endregion Methods
    }
}