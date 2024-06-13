using AutoMapper;
using ECommerceAPI.Application.Features.Product.Tags.Queries.GetTagById.DTOs;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Tags.Queries.GetTagById
{
    public class GetTagByIdMappingProfile : Profile
    {
        public GetTagByIdMappingProfile()
        {
            CreateMap<Tag, GetTagByIdQueryDTO>();
        }
    }
}