using ECommerceAPI.Application.Features.Product.ProductTags.Commands.AddProductTag.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.ProductTags.Commands.AddProductTag.Requests
{
    public class AddProductTagCommandRequest : IRequest<Response<AddProductTagCommandDTO>>
    {
        #region Properties

        public int ProductId { get; set; }
        public int TagId { get; set; }

        #endregion Properties
    }
}