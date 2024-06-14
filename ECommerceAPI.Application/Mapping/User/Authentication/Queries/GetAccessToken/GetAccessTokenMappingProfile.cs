using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication.Token;
using ECommerceAPI.Application.Features.User.Authentications.Queries.GetAccessToken.DTOs;

namespace ECommerceAPI.Application.Mapping.User.Authentication.Queries.GetAccessToken
{
    public class GetAccessTokenMappingProfile : Profile
    {
        #region Constructors

        public GetAccessTokenMappingProfile()
        {
            CreateMap<AccessTokenDTO, GetAccessTokenQueryDTO>()
                .ForMember(destination => destination.AccessToken, options => options.MapFrom(source => source.Token))
                .ForMember(destination => destination.AccessTokenExpiresAt, options => options.MapFrom(source => source.ExpiresAt));
        }

        #endregion Constructors
    }
}