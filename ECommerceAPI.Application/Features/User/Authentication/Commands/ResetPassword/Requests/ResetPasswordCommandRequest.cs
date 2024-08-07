﻿using ECommerceAPI.Application.Features.User.Authentication.Commands.ResetPassword.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.User.Authentication.Commands.ResetPassword.Requests
{
    public class ResetPasswordCommandRequest : IRequest<Response<ResetPasswordCommandDTO>>
    {
        #region Properties

        public string UserId { get; set; } = default!;
        public string Token { get; set; } = default!;
        public string NewPassword { get; set; } = default!;
        public string ConfirmNewPassword { get; set; } = default!;

        #endregion Properties
    }
}