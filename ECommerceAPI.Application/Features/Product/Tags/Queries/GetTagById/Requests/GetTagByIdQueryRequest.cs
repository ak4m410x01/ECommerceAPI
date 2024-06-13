using ECommerceAPI.Application.Features.Product.Tags.Queries.GetTagById.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Tags.Queries.GetTagById.Requests
{
    public class GetTagByIdQueryRequest : IRequest<Response<GetTagByIdQueryDTO>>
    {
        #region Properties

        public int Id { get; set; }

        #endregion Properties
    }
}