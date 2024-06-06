using AutoMapper;
using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetAllInventories.DTOs;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Inventories.Queries.GetAllInventories
{
    public class GetAllInventoriesMappingProfile : Profile
    {
        public GetAllInventoriesMappingProfile()
        {
            CreateMap<Inventory, GetAllInventoriesQueryDTO>();
        }
    }
}