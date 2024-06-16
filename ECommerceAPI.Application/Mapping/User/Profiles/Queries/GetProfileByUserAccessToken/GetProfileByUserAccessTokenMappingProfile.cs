using AutoMapper;
using ECommerceAPI.Application.Features.User.Profiles.Queries.GetProfileByUserAccessToken.DTOs;
using ECommerceAPI.Domain.Entities.Users;

namespace ECommerceAPI.Application.Mapping.User.Profiles.Queries.GetProfileByUserAccessToken
{
    public class GetProfileByUserAccessTokenMappingProfile : Profile
    {
        #region Constructors

        public GetProfileByUserAccessTokenMappingProfile()
        {
            CreateMap<UserProfile, GetProfileByUserAccessTokenQueryDTO>()
                .ForMember(destination => destination.Email, options => options.MapFrom(source => source.User!.Email))
                .ForMember(destination => destination.Username, options => options.MapFrom(source => source.User!.UserName))
                .ForMember(destination => destination.FirstName, options => options.MapFrom(source => source.User!.FirstName))
                .ForMember(destination => destination.LastName, options => options.MapFrom(source => source.User!.LastName))
                .ForMember(destination => destination.PhoneNumber, options => options.MapFrom(source => source.User!.PhoneNumber))
                .ForMember(destination => destination.CreatedAt, options => options.MapFrom(source => source.User!.CreatedAt));
        }

        #endregion Constructors
    }
}