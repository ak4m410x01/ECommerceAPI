﻿using Asp.Versioning;
using ECommerceAPI.Application.Features.User.Authentication.Commands.ChangePassword.DTOs;
using ECommerceAPI.Application.Features.User.Authentication.Commands.ChangePassword.Requests;
using ECommerceAPI.Application.Features.User.Authentication.Commands.GetRefreshToken.Requests;
using ECommerceAPI.Application.Features.User.Authentication.Commands.SignUp.DTOs;
using ECommerceAPI.Application.Features.User.Authentication.Commands.SignUp.Requests;
using ECommerceAPI.Application.Features.User.Authentication.Queries.GetAccessToken.Requests;
using ECommerceAPI.Application.Features.User.Authentication.Queries.SignIn.DTOs;
using ECommerceAPI.Application.Features.User.Authentication.Queries.SignIn.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.User.Authentication
{
    [ApiVersion("1.0")]
    public class AuthenticationController : UserAPIBaseController
    {
        #region Constructors

        public AuthenticationController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors

        #region Methods

        [HttpPost("SignUp")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(SignUpCommandDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> SignUpAsync(SignUpCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpPost("SignIn")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(SignInQueryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SignInQueryDTO), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SignInAsync(SignInQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpPost("AccessToken")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(SignInQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAccessTokenAsync(GetAccessTokenQueryRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [HttpPost("RefreshToken")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(SignInQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRefreshTokenAsync(GetRefreshTokenCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        [Authorize()]
        [HttpPost("ChangePassword")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(ChangePasswordCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return ResponseResult(response);
        }

        #endregion Methods
    }
}