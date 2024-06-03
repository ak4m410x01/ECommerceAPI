using ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.Requests
{
    public class SignInQueryRequest : IRequest<Response<SignInQueryDTO>>
    {
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;
    }
}