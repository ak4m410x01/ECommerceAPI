using AutoMapper;
using ECommerceAPI.Application.Features.Product.Categories.Commands.AddCategory.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Commands.AddCategory.Requests;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Categories.Commands.AddCategory
{
    public class AddCategoryMappingProfile : Profile
    {
        public AddCategoryMappingProfile()
        {
            CreateMap<AddCategoryCommandRequest, Category>();

            CreateMap<Category, AddCategoryCommandDTO>()
                .ForMember(destination => destination.ParentCategory, options =>
                                options.MapFrom(source => source.ParentCategory!.Name));
        }
    }
}