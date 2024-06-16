using ECommerceAPI.Application.Features.User.Profiles.Queries.GetProfileByUserAccessToken.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.User.Profiles.Queries.GetProfileByUserAccessToken.Requests
{
    public class GetProfileByUserAccessTokenQueryRequest : IRequest<Response<GetProfileByUserAccessTokenQueryDTO>>
    {
    }
}