using ECommerceAPI.Application.Features.Product.Tags.Commands.AddTag.DTOs;
using ECommerceAPI.Application.Features.Product.Tags.Commands.AddTag.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Product.Tags
{
    public class TagsController : ProductAPIBaseController
    {
        #region Constructors

        public TagsController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors

        [HttpPost]
        [ProducesResponseType(typeof(AddTagCommandDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddAsync(AddTagCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }
    }
}