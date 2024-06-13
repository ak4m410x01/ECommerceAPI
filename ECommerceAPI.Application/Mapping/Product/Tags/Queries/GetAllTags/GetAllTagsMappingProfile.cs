using AutoMapper;
using ECommerceAPI.Application.Features.Product.Tags.Queries.GetAllTags.DTOs;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Tags.Queries.GetAllTags
{
    public class GetAllTagsMappingProfile : Profile
    {
        public GetAllTagsMappingProfile()
        {
            CreateMap<Tag, GetAllTagsQueryDTO>();
        }
    }
}