using AutoMapper;
using ECommerceAPI.Application.Features.Product.Categories.Commands.Add.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Commands.Add.Requests;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Categories.Commands.Add
{
    public class AddMappingProfile : Profile
    {
        public AddMappingProfile()
        {
            CreateMap<AddCategoryCommandRequest, Category>();

            CreateMap<Category, AddCategoryCommandDTO>()
                .ForMember(destination => destination.ParentCategory, options =>
                                options.MapFrom(source => source.ParentCategory!.Name));
        }
    }
}