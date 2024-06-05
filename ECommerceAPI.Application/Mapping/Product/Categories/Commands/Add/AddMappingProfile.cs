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
            CreateMap<AddCommandRequest, Category>();

            CreateMap<Category, AddCommandDTO>()
                .ForMember(destination => destination.ParentCategory, options =>
                                options.MapFrom(source => source.ParentCategory!.Name));
        }
    }
}