using ECommerceAPI.Application.Features.Product.Products.Commands.AddProduct.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Products.Commands.AddProduct.Requests
{
    public class AddProductCommandRequest : IRequest<Response<AddProductCommandDTO>>
    {
        #region Properties

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? SKU { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public int InventoryId { get; set; }
        public int DiscountId { get; set; }

        #endregion Properties
    }
}