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
            CreateMap<AuthenticationResponseDTO, SignUpCommandDTO>()
                .ForMember(destination => destination.AccessToken, options => options.MapFrom(source => source.Token!.AccessToken!.Token))
                .ForMember(destination => destination.AccessTokenExpiresAt, options => options.MapFrom(source => source.Token!.AccessToken!.ExpiresAt))
                .ForMember(destination => destination.RefreshToken, options => options.MapFrom(source => source.Token!.RefreshToken!.Token))
                .ForMember(destination => destination.RefreshTokenExpiresAt, options => options.MapFrom(source => source.Token!.RefreshToken!.ExpiresAt));
        }
    }
}