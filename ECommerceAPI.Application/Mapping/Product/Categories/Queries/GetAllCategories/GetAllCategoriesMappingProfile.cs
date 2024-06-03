using AutoMapper;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.DTOs;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesMappingProfile : Profile
    {
        public GetAllCategoriesMappingProfile()
        {
            CreateMap<Category, GetAllCategoriesQueryDTO>()
                 .ForMember(destination => destination.ParentCategory, options =>
                                  options.MapFrom(source => source.ParentCategory.Name));
        }
    }
}