using ECommerceAPI.Application.Features.Product.Inventories.Commands.Add.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.Add.Requests;
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
        public async Task<IActionResult> GetAllInventoriesAsync([FromQuery] GetAllInventoriesQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddInventoryCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddInventoryAsync(AddInventoryCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }
    }

    #endregion Methods
}