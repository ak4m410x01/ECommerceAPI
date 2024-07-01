using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication.Token;
using ECommerceAPI.Application.Features.User.Authentication.Commands.GetRefreshToken.DTOs;

namespace ECommerceAPI.Application.Mapping.User.Authentication.Commands.GetRefreshToken
{
    public class GetRefreshTokenMappingProfile : Profile
    {
        #region Constructors

        public GetRefreshTokenMappingProfile()
        {
            CreateMap<RefreshTokenDTO, GetRefreshTokenCommandDTO>()
                .ForMember(destination => destination.RefreshToken, options => options.MapFrom(source => source.Token))
                .ForMember(destination => destination.RefreshTokenExpiresAt, options => options.MapFrom(source => source.ExpiresAt));
        }

        #endregion Constructors
    }
}