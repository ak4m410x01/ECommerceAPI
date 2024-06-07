using ECommerceAPI.Application.Features.Product.Discounts.Queries.GetDiscountById.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Discounts.Queries.GetDiscountById.Requests
{
    public class GetDiscountByIdQueryRequest : IRequest<Response<GetDiscountByIdQueryDTO>>
    {
        #region Properties

        public int Id { get; set; }

        #endregion Properties
    }
}