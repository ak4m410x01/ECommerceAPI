using ECommerceAPI.Application.Features.Product.Tags.Commands.AddTag.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Tags.Commands.AddTag.Requests
{
    public class AddTagCommandRequest : IRequest<Response<AddTagCommandDTO>>
    {
        #region Properties

        public string? Name { get; set; }

        #endregion Properties
    }
}