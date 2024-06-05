using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetAllInventories.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Inventories.Queries.GetAllInventories.Requests
{
    public class GetAllInventoriesQueryRequest : IRequest<Response<IQueryable<GetAllInventoriesQueryDTO>>>
    {
    }
}