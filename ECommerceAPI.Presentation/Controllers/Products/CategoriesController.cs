using ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.Requests;
using ECommerceAPI.Presentation.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Products
{
    public class CategoriesController : APIBaseController
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

        #endregion Methods
    }
}