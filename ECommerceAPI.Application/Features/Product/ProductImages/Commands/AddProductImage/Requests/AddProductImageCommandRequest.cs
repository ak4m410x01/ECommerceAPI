using ECommerceAPI.Application.Features.Product.ProductImages.Commands.AddProductImage.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Application.Features.Product.ProductImages.Commands.AddProductImage.Requests
{
    public class AddProductImageCommandRequest : IRequest<Response<AddProductImageCommandDTO>>
    {
        #region Properties

        public int ProductId { get; set; }
        public IFormFile Image { get; set; } = default!;

        #endregion Properties
    }
}