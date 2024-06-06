using ECommerceAPI.Application.Features.Product.Categories.Queries.GetById.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Categories.Queries.GetById.Requests
{
    public class GetCategoryByIdQueryRequest : IRequest<Response<GetCategoryByIdQueryDTO>>
    {
        public int Id { get; set; }
    }
}