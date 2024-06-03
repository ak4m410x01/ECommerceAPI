using ECommerceAPI.Application.Features.User.Authentications.Commands.SignUp.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.User.Authentications.Commands.SignUp.Requests
{
    public class SignUpCommandRequest : IRequest<Response<SignUpCommandDTO>>
    {
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
    }
}