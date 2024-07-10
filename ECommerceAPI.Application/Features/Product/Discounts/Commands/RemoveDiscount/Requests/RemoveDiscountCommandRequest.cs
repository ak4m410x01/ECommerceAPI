using ECommerceAPI.Application.Features.Product.Discounts.Commands.RemoveDiscount.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Discounts.Commands.RemoveDiscount.Requests
{
    public class RemoveDiscountCommandRequest : IRequest<Response<RemoveDiscountCommandDTO>>
    {
        #region Properties

        public int Id { get; set; }

        #endregion Properties
    }
}