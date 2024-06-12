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
            CreateMap<AuthenticationResponseDTO, SignInQueryDTO>()
                .ForMember(destination => destination.AccessToken, options => options.MapFrom(source => source.Token!.AccessToken!.Token))
                .ForMember(destination => destination.AccessTokenExpiresAt, options => options.MapFrom(source => source.Token!.AccessToken!.ExpiresAt))
                .ForMember(destination => destination.RefreshToken, options => options.MapFrom(source => source.Token!.RefreshToken!.Token))
                .ForMember(destination => destination.RefreshTokenExpiresAt, options => options.MapFrom(source => source.Token!.RefreshToken!.ExpiresAt));
        }
    }
}