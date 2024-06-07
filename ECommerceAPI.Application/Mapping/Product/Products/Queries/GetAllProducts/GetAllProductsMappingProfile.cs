using AutoMapper;
using ECommerceAPI.Application.Features.Product.Products.Queries.GetAllProducts.DTOs;
using ProductEntity = ECommerceAPI.Domain.Entities.Products.Product;

namespace ECommerceAPI.Application.Mapping.Product.Products.Queries.GetAllProducts
{
    public class GetAllProductsMappingProfile : Profile
    {
        public GetAllProductsMappingProfile()
        {
            CreateMap<ProductEntity, GetAllProductsQueryDTO>();
        }
    }
}