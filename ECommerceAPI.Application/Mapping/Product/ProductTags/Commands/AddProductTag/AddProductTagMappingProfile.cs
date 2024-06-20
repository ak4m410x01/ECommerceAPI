using AutoMapper;
using ECommerceAPI.Application.Features.Product.ProductTags.Commands.AddProductTag.DTOs;
using ECommerceAPI.Application.Features.Product.ProductTags.Commands.AddProductTag.Requests;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.ProductTags.Commands.AddProductTag
{
    public class AddProductTagMappingProfile : Profile
    {
        #region Constructors

        public AddProductTagMappingProfile()
        {
            CreateMap<AddProductTagCommandRequest, ProductTag>();

            CreateMap<ProductTag, AddProductTagCommandDTO>()
                .ForMember(destination => destination.Product, options => options.MapFrom(source => source.Product!.Name))
                .ForMember(destination => destination.Tag, options => options.MapFrom(source => source.Tag!.Name));
        }

        #endregion Constructors
    }
}