using AutoMapper;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetById.DTOs;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Categories.Queries.GetById
{
    public class GetByIdMappingProfile : Profile
    {
        public GetByIdMappingProfile()
        {
            CreateMap<Category, GetByIdQueryDTO>()
                .ForMember(destination => destination.ParentCategory, options =>
                                options.MapFrom(source => source.ParentCategory!.Name));
        }
    }
}