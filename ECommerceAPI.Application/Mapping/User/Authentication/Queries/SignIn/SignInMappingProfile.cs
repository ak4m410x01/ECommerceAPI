using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication;
using ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.DTOs;
using ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.Requests;
using ECommerceAPI.Domain.IdentityEntities;

namespace ECommerceAPI.Application.Mapping.User.Authentication.Queries.SignIn
{
    public class SignInMappingProfile : Profile
    {
        public SignInMappingProfile()
        {
            CreateMap<ApplicationUser, AuthenticationResponseDTO>()
                 .ForMember(destination => destination.UserId, options =>
                                   options.MapFrom(source => source.Id));

            CreateMap<SignInQueryRequest, SignInDTO>();
            CreateMap<AuthenticationResponseDTO, SignInQueryDTO>();
        }
    }
}