using ECommerceAPI.Application.Features.Product.Categories.Commands.AddCategory.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Categories.Commands.AddCategory.Requests
{
    public class AddCategoryCommandRequest : IRequest<Response<AddCategoryCommandDTO>>
    {
        #region Properties

        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ParentCategoryId { get; set; }

        #endregion Properties
    }
}