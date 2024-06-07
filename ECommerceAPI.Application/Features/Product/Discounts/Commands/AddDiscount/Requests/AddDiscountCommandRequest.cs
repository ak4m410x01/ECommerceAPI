using ECommerceAPI.Application.Features.Product.Discounts.Commands.AddDiscount.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Discounts.Commands.AddDiscount.Requests
{
    public class AddDiscountCommandRequest : IRequest<Response<AddDiscountCommandDTO>>
    {
        #region Properties

        public string? Code { get; set; }
        public string? Description { get; set; }
        public decimal Percent { get; set; }
        public int MaxUses { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

        #endregion Properties
    }
}