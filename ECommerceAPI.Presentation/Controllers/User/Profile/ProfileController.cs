using Asp.Versioning;
using ECommerceAPI.Application.Features.User.Profiles.Queries.GetProfileByUserAccessToken.DTOs;
using ECommerceAPI.Application.Features.User.Profiles.Queries.GetProfileByUserAccessToken.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.User.Profile
{
    [Authorize]
    [ApiVersion("1.0")]
    public class ProfileController : UserAPIBaseController
    {
        #region Constructors

        public ProfileController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(GetProfileByUserAccessTokenQueryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetProfileByUserAccessTokenQueryDTO), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GetProfileByUserAccessTokenQueryDTO), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetProfileByUserAccessToken([FromQuery] GetProfileByUserAccessTokenQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }
    }
}