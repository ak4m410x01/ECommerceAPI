using AutoMapper;
using ECommerceAPI.Application.Features.Product.ProductRecommendations.Commands.AddProductRecommendation.DTOs;
using ECommerceAPI.Application.Features.Product.ProductRecommendations.Commands.AddProductRecommendation.Requests;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.ProductRecommendations.Commands.AddProductRecommendation
{
    public class AddProductRecommendationMappingProfile : Profile
    {
        #region Constructors

        public AddProductRecommendationMappingProfile()
        {
            CreateMap<AddProductRecommendationCommandRequet, ProductRecommendation>();

            CreateMap<ProductRecommendation, AddProductRecommendationCommandDTO>()
                .ForMember(destination => destination.Product, options => options.MapFrom(source => source.Product!.Name))
                .ForMember(destination => destination.RecommendedProduct, options => options.MapFrom(source => source.RecommendedProduct!.Name));
        }

        #endregion Constructors
    }
}