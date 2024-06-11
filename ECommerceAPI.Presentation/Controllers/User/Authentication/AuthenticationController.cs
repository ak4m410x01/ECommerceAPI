using ECommerceAPI.Application.Features.User.Authentications.Commands.ChangePassword.DTOs;
using ECommerceAPI.Application.Features.User.Authentications.Commands.ChangePassword.Requests;
using ECommerceAPI.Application.Features.User.Authentications.Commands.SignUp.DTOs;
using ECommerceAPI.Application.Features.User.Authentications.Commands.SignUp.Requests;
using ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.DTOs;
using ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.User.Authentication
{
    public class AuthenticationController : UserAPIBaseController
    {
        #region Constructors

        public AuthenticationController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors

        #region Methods

        [HttpPost("SignUp")]
        [ProducesResponseType(typeof(SignUpCommandDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(SignUpCommandDTO), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUpAsync(SignUpCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpPost("SignIn")]
        [ProducesResponseType(typeof(SignInQueryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SignInQueryDTO), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SignInAsync(SignInQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [Authorize()]
        [HttpPost("ChangePassword")]
        [ProducesResponseType(typeof(ChangePasswordCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        #endregion Methods
    }
}