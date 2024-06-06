using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetInventoryById.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Inventories.Queries.GetInventoryById.Requests
{
    public class GetInventoryByIdQueryRequest : IRequest<Response<GetInventoryByIdQueryDTO>>
    {
        public int Id { get; set; }
    }
}