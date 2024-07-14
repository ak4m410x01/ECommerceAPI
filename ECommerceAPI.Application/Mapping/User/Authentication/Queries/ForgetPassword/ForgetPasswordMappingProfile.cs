using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication.ForgetPassword;
using ECommerceAPI.Application.Features.User.Authentication.Queries.ForgetPassword.DTOs;
using ECommerceAPI.Application.Features.User.Authentication.Queries.ForgetPassword.Requests;

namespace ECommerceAPI.Application.Mapping.User.Authentication.Queries.ForgetPassword
{
    public class ForgetPasswordMappingProfile : Profile
    {
        #region Constructors

        public ForgetPasswordMappingProfile()
        {
            CreateMap<ForgetPasswordQueryRequest, ForgetPasswordDTORequest>();
            CreateMap<ForgetPasswordDTORequest, ForgetPasswordQueryDTO>();
        }

        #endregion Constructors
    }
}