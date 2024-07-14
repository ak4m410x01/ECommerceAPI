using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication.ResetPassword;
using ECommerceAPI.Application.Features.User.Authentication.Queries.ResetPassword.DTOs;
using ECommerceAPI.Application.Features.User.Authentication.Queries.ResetPassword.Requests;

namespace ECommerceAPI.Application.Mapping.User.Authentication.Queries.ResetPassword
{
    public class ResetPasswordMappingProfile : Profile
    {
        #region Constructor

        public ResetPasswordMappingProfile()
        {
            CreateMap<ResetPasswordQueryRequest, ResetPasswordDTORequest>();
            CreateMap<ResetPasswordDTORequest, ResetPasswordQueryDTO>();
        }

        #endregion Constructor
    }
}