using AutoMapper;
using ECommerceAPI.Application.Features.Product.ProductImages.Commands.AddProductImage.DTOs;
using ECommerceAPI.Application.Features.Product.ProductImages.Commands.AddProductImage.Requests;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.ProductImages.Commands.AddProductImage
{
    public class AddProductImageMappingProfile : Profile
    {
        #region Constructors

        public AddProductImageMappingProfile()
        {
            CreateMap<AddProductImageCommandRequest, ProductImage>();
            CreateMap<ProductImage, AddProductImageCommandDTO>();
        }

        #endregion Constructors
    }
}