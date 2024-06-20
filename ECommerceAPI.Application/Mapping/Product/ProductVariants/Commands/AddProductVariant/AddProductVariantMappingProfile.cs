using AutoMapper;
using ECommerceAPI.Application.Features.Product.ProductVariants.Commands.AddProductVariant.DTOs;
using ECommerceAPI.Application.Features.Product.ProductVariants.Commands.AddProductVariant.Requests;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.ProductVariants.Commands.AddProductVariant
{
    public class AddProductVariantMappingProfile : Profile
    {
        #region Constructors

        public AddProductVariantMappingProfile()
        {
            CreateMap<AddProductVariantCommandRequest, ProductVariant>();
            CreateMap<ProductVariant, AddProductVariantCommandDTO>()
                .ForMember(destination => destination.Product, options => options.MapFrom(source => source.Product!.Name));
        }

        #endregion Constructors
    }
}