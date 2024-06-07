using AutoMapper;
using ECommerceAPI.Application.Features.Product.Products.Queries.GetProductById.DTOs;
using ProductEntity = ECommerceAPI.Domain.Entities.Products.Product;

namespace ECommerceAPI.Application.Mapping.Product.Products.Queries.GetProductById
{
    public class GetProductByIdMappingProfile : Profile
    {
        public GetProductByIdMappingProfile()
        {
            CreateMap<ProductEntity, GetProductByIdQueryDTO>()
                .ForMember(destination => destination.Category, options => options.MapFrom(source => source.Category!.Name))
                .ForMember(destination => destination.Inventory, options => options.MapFrom(source => source.Inventory!.Quantity))
                .ForMember(destination => destination.Discount, options => options.MapFrom(source => source.Discount!.Code));
        }
    }
}