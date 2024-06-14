using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication.SignIn;
using ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.DTOs;
using ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.Requests;

namespace ECommerceAPI.Application.Mapping.User.Authentication.Queries.SignIn
{
    public class SignInMappingProfile : Profile
    {
        #region Constructors

        public SignInMappingProfile()
        {
            CreateMap<SignInQueryRequest, SignInDTORequest>();
            CreateMap<SignInDTOResponse, SignInQueryDTO>()
                .ForMember(destination => destination.AccessToken, options => options.MapFrom(source => source.AccessToken!.Token))
                .ForMember(destination => destination.AccessTokenExpiresAt, options => options.MapFrom(source => source.AccessToken!.ExpiresAt))
                .ForMember(destination => destination.RefreshToken, options => options.MapFrom(source => source.RefreshToken!.Token))
                .ForMember(destination => destination.RefreshTokenExpiresAt, options => options.MapFrom(source => source.RefreshToken!.ExpiresAt));
        }

        #endregion Constructors
    }
}