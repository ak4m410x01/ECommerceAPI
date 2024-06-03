using ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.Requests;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetById.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Product.Categories
{
    public class CategoriesController : ProductAPIBaseController
    {
        #region Properties

        private readonly IMediator _mediator;

        #endregion Properties

        #region Constructors

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion Constructors

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllCategoriesQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        #endregion Methods
    }
}