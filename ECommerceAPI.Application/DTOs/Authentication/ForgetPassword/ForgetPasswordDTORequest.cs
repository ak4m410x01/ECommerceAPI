using ECommerceAPI.Application.Features.User.Authentication.Queries.ForgetPassword.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.DTOs.Authentication.ForgetPassword
{
    public class ForgetPasswordDTORequest : IRequest<Response<ForgetPasswordQueryDTO>>
    {
        #region Properties

        public string Email { get; set; } = default!;

        #endregion Properties
    }
}