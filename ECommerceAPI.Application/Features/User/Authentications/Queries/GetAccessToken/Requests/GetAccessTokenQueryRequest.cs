using ECommerceAPI.Application.Features.User.Authentications.Queries.GetAccessToken.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.User.Authentications.Queries.GetAccessToken.Requests
{
    public class GetAccessTokenQueryRequest : IRequest<Response<GetAccessTokenQueryDTO>>
    {
        public string RefreshToken { get; set; } = default!;
    }
}