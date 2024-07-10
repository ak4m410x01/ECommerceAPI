using AutoMapper;
using ECommerceAPI.Application.Features.Product.Discounts.Commands.UpdateDiscount.DTOs;
using ECommerceAPI.Application.Features.Product.Discounts.Commands.UpdateDiscount.Requests;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Discounts.Commands.UpdateDiscount
{
    public class UpdateDiscountMappingProfile : Profile
    {
        #region Constructors

        public UpdateDiscountMappingProfile()
        {
            CreateMap<UpdateDiscountCommandRequest, Discount>()
                .ForMember(destination => destination.Code, options => options.Condition(source => source.Code != null))
                .ForMember(destination => destination.Description, options => options.Condition(source => source.Description != null))
                .ForMember(destination => destination.Percent, options => options.Condition(source => source.Percent != null))
                .ForMember(destination => destination.MaxUses, options => options.Condition(source => source.MaxUses != null))
                .ForMember(destination => destination.StartAt, options => options.Condition(source => source.StartAt != null))
                .ForMember(destination => destination.EndAt, options => options.Condition(source => source.EndAt != null));

            CreateMap<Discount, UpdateDiscountCommandDTO>();
        }

        #endregion Constructors
    }
}