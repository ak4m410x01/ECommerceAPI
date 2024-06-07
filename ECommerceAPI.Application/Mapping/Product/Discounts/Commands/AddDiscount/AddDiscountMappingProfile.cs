using AutoMapper;
using ECommerceAPI.Application.Features.Product.Discounts.Commands.AddDiscount.DTOs;
using ECommerceAPI.Application.Features.Product.Discounts.Commands.AddDiscount.Requests;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Discounts.Commands.AddDiscount
{
    public class AddDiscountMappingProfile : Profile
    {
        public AddDiscountMappingProfile()
        {
            CreateMap<AddDiscountCommandRequest, Discount>();
            CreateMap<Discount, AddDiscountCommandDTO>();
        }
    }
}