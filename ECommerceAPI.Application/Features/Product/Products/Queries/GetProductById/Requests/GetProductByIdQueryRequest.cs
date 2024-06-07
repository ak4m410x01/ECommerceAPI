using ECommerceAPI.Application.Features.Product.Products.Queries.GetProductById.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Products.Queries.GetProductById.Requests
{
    public class GetProductByIdQueryRequest : IRequest<Response<GetProductByIdQueryDTO>>
    {
        #region Properties

        public int Id { get; set; }

        #endregion Properties
    }
}