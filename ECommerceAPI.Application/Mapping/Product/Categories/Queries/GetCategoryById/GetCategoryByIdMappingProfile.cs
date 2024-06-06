using AutoMapper;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetCategoryById.DTOs;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdMappingProfile : Profile
    {
        public GetCategoryByIdMappingProfile()
        {
            CreateMap<Category, GetCategoryByIdQueryDTO>()
                .ForMember(destination => destination.ParentCategory, options =>
                                options.MapFrom(source => source.ParentCategory!.Name));
        }
    }
}