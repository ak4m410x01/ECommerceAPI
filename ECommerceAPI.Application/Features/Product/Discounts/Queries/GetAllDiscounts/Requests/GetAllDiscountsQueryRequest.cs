using ECommerceAPI.Application.Features.Product.Discounts.Queries.GetAllDiscounts.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Discounts.Queries.GetAllDiscounts.Requests
{
    public class GetAllDiscountsQueryRequest : PaginatedRequest, IRequest<PaginatedResponse<GetAllDiscountsQueryDTO>>
    {
    }
}