using ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.Requests
{
    public class GetAllCategoriesQueryRequest : IRequest<Response<IQueryable<GetAllCategoriesQueryDTO>>>
    {
    }
}