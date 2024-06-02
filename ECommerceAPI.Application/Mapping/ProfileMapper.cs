using AutoMapper;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.DTOs;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Category, GetAllCategoriesQueryDTO>()
                 .ForMember(destination => destination.ParentCategory, options => options.MapFrom(source => source.ParentCategory.Name));
        }
    }
}