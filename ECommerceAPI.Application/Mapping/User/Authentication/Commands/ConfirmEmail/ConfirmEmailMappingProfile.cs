using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication.ConfirmEmail;
using ECommerceAPI.Application.Features.User.Authentication.Commands.ConfirmEmail.DTOs;
using ECommerceAPI.Application.Features.User.Authentication.Commands.ConfirmEmail.Requests;

namespace ECommerceAPI.Application.Mapping.User.Authentication.Commands.ConfirmEmail
{
    public class ConfirmEmailMappingProfile : Profile
    {
        #region Constructors

        public ConfirmEmailMappingProfile()
        {
            CreateMap<ConfirmEmailCommandRequest, ConfirmEmailDTORequest>();

            CreateMap<ConfirmEmailDTOResponse, ConfirmEmailCommandDTO>();
        }

        #endregion Constructors
    }
}