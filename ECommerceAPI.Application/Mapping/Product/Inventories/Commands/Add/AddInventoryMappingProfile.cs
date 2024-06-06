using AutoMapper;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.Add.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.Add.Requests;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Inventories.Commands.Add
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