using AutoMapper;
using ECommerceAPI.Application.Features.Product.Discounts.Queries.GetAllDiscounts.DTOs;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Discounts.Queries.GetAllDiscounts
{
    public class GetAllDiscountsMappingProfile : Profile
    {
        public GetAllDiscountsMappingProfile()
        {
            CreateMap<Discount, GetAllDiscountsQueryDTO>();
        }
    }
}