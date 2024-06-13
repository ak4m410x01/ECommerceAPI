using AutoMapper;
using ECommerceAPI.Application.Features.Product.Tags.Commands.AddTag.DTOs;
using ECommerceAPI.Application.Features.Product.Tags.Commands.AddTag.Requests;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Tags.Commands.AddTag
{
    public class AddTagMappingProfile : Profile
    {
        public AddTagMappingProfile()
        {
            CreateMap<AddTagCommandRequest, Tag>();
            CreateMap<Tag, AddTagCommandDTO>();
        }
    }
}