using AutoMapper;
using ECommerceAPI.Application.Features.Product.Discounts.Queries.GetDiscountById.DTOs;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Discounts.Queries.GetDiscountById
{
    public class GetDiscountByIdMappingProfile : Profile
    {
        public GetDiscountByIdMappingProfile()
        {
            CreateMap<Discount, GetDiscountByIdQueryDTO>();
        }
    }
}