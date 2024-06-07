using AutoMapper;
using ECommerceAPI.Application.Features.Product.Products.Commands.AddProduct.DTOs;
using ECommerceAPI.Application.Features.Product.Products.Commands.AddProduct.Requests;
using ProductEntity = ECommerceAPI.Domain.Entities.Products.Product;

namespace ECommerceAPI.Application.Mapping.Product.Products.Commands.AddProduct
{
    public class AddProductMappingProfile : Profile
    {
        public AddProductMappingProfile()
        {
            CreateMap<AddProductCommandRequest, ProductEntity>();
            CreateMap<ProductEntity, AddProductCommandDTO>()
                .ForMember(destination => destination.Category, options => options.MapFrom(source => source.Category!.Name))
                .ForMember(destination => destination.Inventory, options => options.MapFrom(source => source.Inventory!.Quantity))
                .ForMember(destination => destination.Discount, options => options.MapFrom(source => source.Discount!.Code));
        }
    }
}