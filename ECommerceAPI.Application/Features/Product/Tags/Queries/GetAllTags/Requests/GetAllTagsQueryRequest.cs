using ECommerceAPI.Application.Features.Product.Tags.Queries.GetAllTags.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Tags.Queries.GetAllTags.Requests
{
    public class GetAllTagsQueryRequest : PaginatedRequest, IRequest<PaginatedResponse<GetAllTagsQueryDTO>>
    {
    }
}