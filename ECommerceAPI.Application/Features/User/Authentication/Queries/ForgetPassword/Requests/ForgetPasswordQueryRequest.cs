using ECommerceAPI.Application.Features.User.Authentication.Queries.ForgetPassword.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.User.Authentication.Queries.ForgetPassword.Requests
{
    public class ForgetPasswordQueryRequest : IRequest<Response<ForgetPasswordQueryDTO>>
    {
        #region Properties

        public string Email { get; set; } = default!;

        #endregion Properties
    }
}