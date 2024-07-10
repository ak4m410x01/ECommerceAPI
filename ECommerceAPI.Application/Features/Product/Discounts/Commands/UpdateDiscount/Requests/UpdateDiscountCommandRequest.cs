using ECommerceAPI.Application.Features.Product.Discounts.Commands.UpdateDiscount.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Discounts.Commands.UpdateDiscount.Requests
{
    public class UpdateDiscountCommandRequest : IRequest<Response<UpdateDiscountCommandDTO>>
    {
        #region Properties

        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public decimal? Percent { get; set; }
        public int? MaxUses { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }

        #endregion Properties
    }
}