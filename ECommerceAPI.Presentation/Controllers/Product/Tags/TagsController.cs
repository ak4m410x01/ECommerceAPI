using Asp.Versioning;
using ECommerceAPI.Application.Features.Product.Tags.Commands.AddTag.DTOs;
using ECommerceAPI.Application.Features.Product.Tags.Commands.AddTag.Requests;
using ECommerceAPI.Application.Features.Product.Tags.Queries.GetAllTags.DTOs;
using ECommerceAPI.Application.Features.Product.Tags.Queries.GetAllTags.Requests;
using ECommerceAPI.Application.Features.Product.Tags.Queries.GetTagById.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Product.Tags
{
    [ApiVersion("1.0")]
    public class TagsController : ProductAPIBaseController
    {
        #region Constructors

        public TagsController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors

        #region Methods

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(GetAllTagsQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllTagsAsync([FromQuery] GetAllTagsQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(AddTagCommandDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddAsync(AddTagCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpGet("{id:int}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(GetAllTagsQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTagByIdAsync([FromRoute] GetTagByIdQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        #endregion Methods
    }
}