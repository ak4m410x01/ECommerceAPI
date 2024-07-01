using ECommerceAPI.Application.Features.User.Authentication.Commands.GetRefreshToken.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.User.Authentication.Commands.GetRefreshToken.Requests
{
    public class GetRefreshTokenCommandRequest : IRequest<Response<GetRefreshTokenCommandDTO>>
    {
        #region Properties

        public string RefreshToken { get; set; } = default!;

        #endregion Properties
    }
}