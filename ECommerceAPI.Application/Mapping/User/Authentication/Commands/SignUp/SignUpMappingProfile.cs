using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication.SignUp;
using ECommerceAPI.Application.Features.User.Authentication.Commands.SignUp.DTOs;
using ECommerceAPI.Application.Features.User.Authentication.Commands.SignUp.Requests;
using ECommerceAPI.Domain.IdentityEntities;

namespace ECommerceAPI.Application.Mapping.User.Authentication.Commands.SignUp
{
    public class SignUpMappingProfile : Profile
    {
        #region Constructors

        public SignUpMappingProfile()
        {
            CreateMap<SignUpDTORequest, ApplicationUser>();

            CreateMap<SignUpCommandRequest, SignUpDTORequest>();
            CreateMap<SignUpDTOResponse, SignUpCommandDTO>();
        }

        #endregion Constructors
    }
}