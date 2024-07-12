using ECommerceAPI.Application.Features.User.Authentication.Commands.ConfirmEmail.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.User.Authentication.Commands.ConfirmEmail.Requests
{
    public class ConfirmEmailCommandRequest : IRequest<Response<ConfirmEmailCommandDTO>>
    {
        #region Properties

        public string UserId { get; set; } = default!;
        public string Token { get; set; } = default!;

        #endregion Properties
    }
}