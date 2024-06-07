using ECommerceAPI.Application.Features.Product.Products.Commands.AddProduct.DTOs;
using ECommerceAPI.Application.Features.Product.Products.Commands.AddProduct.Requests;
using ECommerceAPI.Application.Features.Product.Products.Queries.GetAllProducts.DTOs;
using ECommerceAPI.Application.Features.Product.Products.Queries.GetAllProducts.Requests;
using ECommerceAPI.Application.Features.Product.Products.Queries.GetProductById.DTOs;
using ECommerceAPI.Application.Features.Product.Products.Queries.GetProductById.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Product.Products
{
    public class ProductsController : ProductAPIBaseController
    {
        #region Constructors

        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors

        #region Methods

        [HttpGet]
        [ProducesResponseType(typeof(GetAllProductsQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProductsAsync([FromQuery] GetAllProductsQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddProductCommandDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddProductAsync(AddProductCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GetProductByIdQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductByIdAsync([FromRoute] GetProductByIdQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        #endregion Methods
    }
}