using ECommerceAPI.Application.Features.Product.Categories.Queries.GetCategoryById.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Categories.Queries.GetCategoryById.Requests
{
    public class GetCategoryByIdQueryRequest : IRequest<Response<GetCategoryByIdQueryDTO>>
    {
        #region Properties

        public int Id { get; set; }

        #endregion Properties
    }
}