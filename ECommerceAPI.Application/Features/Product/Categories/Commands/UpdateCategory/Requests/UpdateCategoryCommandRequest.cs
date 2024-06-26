using ECommerceAPI.Application.Features.Product.Categories.Commands.UpdateCategory.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Categories.Commands.UpdateCategory.Requests
{
    public class UpdateCategoryCommandRequest : IRequest<Response<UpdateCategoryCommandDTO>>
    {
        #region Properties

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ParentCategoryId { get; set; }

        #endregion Properties
    }
}