using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication;
using ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.DTOs;
using ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.Requests;

namespace ECommerceAPI.Application.Mapping.User.Authentication.Queries.SignIn
{
    public class SignInMappingProfile : Profile
    {
        public SignInMappingProfile()
        {
            CreateMap<SignInQueryRequest, SignInDTO>();
            CreateMap<AuthenticationResponseDTO, SignInQueryDTO>();
        }
    }
}