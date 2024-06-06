using AutoMapper;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.AddInventory.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.AddInventory.Requests;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Inventories.Commands.AddInventory
{
    public class AddInventoryMappingProfile : Profile
    {
        public AddInventoryMappingProfile()
        {
            CreateMap<AddInventoryCommandRequest, Inventory>();
            CreateMap<Inventory, AddInventoryCommandDTO>();
        }
    }
}