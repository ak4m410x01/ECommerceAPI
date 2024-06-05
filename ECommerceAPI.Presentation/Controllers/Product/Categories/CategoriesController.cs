using ECommerceAPI.Application.Features.Product.Categories.Commands.Add.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Commands.Add.Requests;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.Requests;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetById.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetById.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Product.Categories
{
    public class CategoriesController : ProductAPIBaseController
    {
        #region Constructors

        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors

        #region Methods

        [HttpGet]
        [ProducesResponseType(typeof(GetAllCategoriesQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllCategoriesQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(typeof(GetByIdQueryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetByIdQueryDTO), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddCommandDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AddCommandDTO), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync(AddCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        #endregion Methods
    }
}