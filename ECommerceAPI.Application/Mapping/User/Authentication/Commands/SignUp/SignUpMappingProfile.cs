using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication;
using ECommerceAPI.Application.Features.User.Authentications.Commands.SignUp.DTOs;
using ECommerceAPI.Application.Features.User.Authentications.Commands.SignUp.Requests;
using ECommerceAPI.Domain.IdentityEntities;

namespace ECommerceAPI.Application.Mapping.User.Authentication.Commands.SignUp
{
    public class SignUpMappingProfile : Profile
    {
        public SignUpMappingProfile()
        {
            CreateMap<SignUpDTO, ApplicationUser>();

            CreateMap<SignUpCommandRequest, SignUpDTO>();
            CreateMap<AuthenticationResponseDTO, SignUpCommandDTO>();
        }
    }
}