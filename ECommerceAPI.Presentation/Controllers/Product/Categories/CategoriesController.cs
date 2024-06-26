using Asp.Versioning;
using ECommerceAPI.Application.Features.Product.Categories.Commands.AddCategory.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Commands.AddCategory.Requests;
using ECommerceAPI.Application.Features.Product.Categories.Commands.RemoveCategory.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Commands.RemoveCategory.Requests;
using ECommerceAPI.Application.Features.Product.Categories.Commands.UpdateCategory.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Commands.UpdateCategory.Requests;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.Requests;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetCategoryById.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetCategoryById.Requests;
using ECommerceAPI.Domain.Enumerations.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Product.Categories
{
    [ApiVersion("1.0")]
    public class CategoriesController : ProductAPIBaseController
    {
        #region Constructors

        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors

        #region Methods

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(GetAllCategoriesQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategoriesAsync([FromQuery] GetAllCategoriesQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(AddCategoryCommandDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddCategoryAsync([FromBody] AddCategoryCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpGet("{id:int}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(GetCategoryByIdQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCategoryByIdAsync([FromRoute] GetCategoryByIdQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpPut("{id:int}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(UpdateCategoryCommandDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> UpdateCategoryAsync(int id, [FromBody] UpdateCategoryCommandRequest request)
        {
            request.Id = id;
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpDelete("{id:int}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(RemoveCategoryCommandDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> RemoveCategoryAsync([FromRoute] RemoveCategoryCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        #endregion Methods
    }
}