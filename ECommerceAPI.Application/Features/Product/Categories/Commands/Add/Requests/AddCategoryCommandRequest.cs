using ECommerceAPI.Application.Features.Product.Categories.Commands.Add.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Categories.Commands.Add.Requests
{
    public class AddCategoryCommandRequest : IRequest<Response<AddCategoryCommandDTO>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int ParentCategoryId { get; set; }
    }
}