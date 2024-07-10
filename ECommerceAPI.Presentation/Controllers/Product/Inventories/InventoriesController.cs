using Asp.Versioning;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.AddInventory.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.AddInventory.Requests;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.RemoveInventory.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.RemoveInventory.Requests;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.UpdateInventory.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.UpdateInventory.Requests;
using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetAllInventories.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetAllInventories.Requests;
using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetInventoryById.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetInventoryById.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Product.Inventories
{
    [ApiVersion("1.0")]
    public class InventoriesController : ProductAPIBaseController
    {
        #region Constructors

        public InventoriesController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors

        #region Methods

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = "SuperAdmin,Admin,Customer")]
        [ProducesResponseType(typeof(GetAllInventoriesQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllInventoriesAsync([FromQuery] GetAllInventoriesQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ProducesResponseType(typeof(AddInventoryCommandDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddInventoryAsync(AddInventoryCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpGet("{id:int}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = "SuperAdmin,Admin,Customer")]
        [ProducesResponseType(typeof(GetInventoryByIdQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetInventoryByIdAsync([FromRoute] GetInventoryByIdQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpPut("{id:int}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ProducesResponseType(typeof(UpdateInventoryCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateInventoryAsync([FromRoute] UpdateInventoryCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpDelete("{id:int}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ProducesResponseType(typeof(RemoveInventoryCommandDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> RemoveInventoryAsync([FromRoute] RemoveInventoryCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }
    }

    #endregion Methods
}