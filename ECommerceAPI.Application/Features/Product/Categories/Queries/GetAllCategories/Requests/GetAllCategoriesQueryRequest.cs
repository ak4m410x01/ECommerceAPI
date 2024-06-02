using ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.DTOs;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.Requests
{
    public class GetAllCategoriesQueryRequest : IRequest<IQueryable<GetAllCategoriesQueryDTO>>
    {
    }
}