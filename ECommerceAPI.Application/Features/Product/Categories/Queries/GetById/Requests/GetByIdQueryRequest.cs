using ECommerceAPI.Application.Features.Product.Categories.Queries.GetById.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Categories.Queries.GetById.Requests
{
    public class GetByIdQueryRequest : IRequest<Response<GetByIdQueryDTO>>
    {
        public int Id { get; set; }
    }
}