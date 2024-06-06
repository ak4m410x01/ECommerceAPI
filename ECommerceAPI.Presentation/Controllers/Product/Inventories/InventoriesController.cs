using ECommerceAPI.Application.Features.Product.Inventories.Commands.AddInventory.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.AddInventory.Requests;
using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetAllInventories.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetAllInventories.Requests;
using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetInventoryById.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetInventoryById.Requests;
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

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GetInventoryByIdQueryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetInventoryByIdQueryDTO), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInventoryByIdAsync([FromRoute] GetInventoryByIdQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }
    }

    #endregion Methods
}