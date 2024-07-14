using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication.ResetPassword;
using ECommerceAPI.Application.Features.User.Authentication.Commands.ResetPassword.DTOs;
using ECommerceAPI.Application.Features.User.Authentication.Commands.ResetPassword.Requests;

namespace ECommerceAPI.Application.Mapping.User.Authentication.Commands.ResetPassword
{
    public class ResetPasswordMappingProfile : Profile
    {
        #region Constructor

        public ResetPasswordMappingProfile()
        {
            CreateMap<ResetPasswordCommandRequest, ResetPasswordDTORequest>();
            CreateMap<ResetPasswordDTOResponse, ResetPasswordCommandDTO>();
        }

        #endregion Constructor
    }
}