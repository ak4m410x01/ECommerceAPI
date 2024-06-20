using ECommerceAPI.Application.Features.Product.ProductVariants.Commands.AddProductVariant.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.ProductVariants.Commands.AddProductVariant.Requests
{
    public class AddProductVariantCommandRequest : IRequest<Response<AddProductVariantCommandDTO>>
    {
        #region Properties

        public int ProductId { get; set; }
        public string Name { get; set; } = default!;
        public string Value { get; set; } = default!;

        #endregion Properties
    }
}