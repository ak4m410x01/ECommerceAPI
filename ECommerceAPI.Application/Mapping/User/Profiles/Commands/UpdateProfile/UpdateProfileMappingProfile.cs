using AutoMapper;
using ECommerceAPI.Application.Features.User.Profiles.Commands.UpdateProfile.DTOs;
using ECommerceAPI.Domain.Entities.Users;
using ECommerceAPI.Domain.IdentityEntities;

namespace ECommerceAPI.Application.Mapping.User.Profiles.Commands.UpdateProfile
{
    public class UpdateProfileMappingProfile : Profile
    {
        #region Constructors

        public UpdateProfileMappingProfile()
        {
            CreateMap<ApplicationUser, UpdateProfileCommandDTO>()
                .ForMember(destination => destination.Bio, options => options.MapFrom(source => source.UserProfile!.Bio));
        }

        #endregion Constructors
    }
}