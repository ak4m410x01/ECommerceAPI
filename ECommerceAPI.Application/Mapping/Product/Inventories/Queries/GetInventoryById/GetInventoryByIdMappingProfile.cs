using AutoMapper;
using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetInventoryById.DTOs;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Inventories.Queries.GetInventoryById
{
    public class GetInventoryByIdMappingProfile : Profile
    {
        public GetInventoryByIdMappingProfile()
        {
            CreateMap<Inventory, GetInventoryByIdQueryDTO>();
        }
    }
}