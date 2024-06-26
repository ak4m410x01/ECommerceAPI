using ECommerceAPI.Application.Features.Product.Categories.Commands.RemoveCategory.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Categories.Commands.RemoveCategory.Requests
{
    public class RemoveCategoryCommandRequest : IRequest<Response<RemoveCategoryCommandDTO>>
    {
        #region Properties

        public int Id { get; set; }

        #endregion Properties
    }
}