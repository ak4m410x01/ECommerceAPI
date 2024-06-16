using ECommerceAPI.Application.Features.User.Profiles.Commands.UpdateProfile.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.User.Profiles.Commands.UpdateProfile.Requests
{
    public class UpdateProfileCommandRequest : IRequest<Response<UpdateProfileCommandDTO>>
    {
        #region Properties

        #region User Properties

        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }

        #endregion User Properties

        #region User Profile Properties

        public string? Bio { get; set; }

        #endregion User Profile Properties

        #endregion Properties
    }
}