using AutoMapper;
using ECommerceAPI.Application.Features.Product.Categories.Commands.UpdateCategory.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Commands.UpdateCategory.Requests;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Categories.Commands.UpdateCategory
{
    internal class UpdateCategoryMappingProfile : Profile
    {
        public UpdateCategoryMappingProfile()
        {
            CreateMap<UpdateCategoryCommandRequest, Category>()
                .ForMember(destination => destination.Name, options => options.Condition(source => source.Name != null))
                .ForMember(destination => destination.Description, options => options.Condition(source => source.Description != null))
                .ForMember(destination => destination.ParentCategoryId, options => options.Condition(source => source.ParentCategoryId != null));

            CreateMap<Category, UpdateCategoryCommandDTO>()
                .ForMember(destination => destination.ParentCategory, options =>
                                options.MapFrom(source => source.ParentCategory!.Name));
        }
    }
}