using ECommerceAPI.Application.Features.User.Authentications.Commands.ChangePassword.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.User.Authentications.Commands.ChangePassword.Requests
{
    public class ChangePasswordCommandRequest : IRequest<Response<ChangePasswordCommandDTO>>
    {
        #region Properties

        public string CurrentPassword { get; set; } = default!;
        public string NewPassword { get; set; } = default!;
        public string ConfirmNewPassword { get; set; } = default!;

        #endregion Properties
    }
}