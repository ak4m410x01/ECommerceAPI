using ECommerceAPI.Application.Features.Product.Products.Queries.GetAllProducts.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Products.Queries.GetAllProducts.Requests
{
    public class GetAllProductsQueryRequest : PaginatedRequest, IRequest<PaginatedResponse<GetAllProductsQueryDTO>>
    {
    }
}