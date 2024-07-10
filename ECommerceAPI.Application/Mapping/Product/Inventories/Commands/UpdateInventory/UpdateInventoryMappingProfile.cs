using AutoMapper;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.UpdateInventory.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.UpdateInventory.Requests;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Mapping.Product.Inventories.Commands.UpdateInventory
{
    public class UpdateInventoryMappingProfile : Profile
    {
        #region Constructors

        public UpdateInventoryMappingProfile()
        {
            CreateMap<UpdateInventoryCommandRequest, Inventory>()
                .ForMember(destination => destination.Quantity, options => options.Condition(source => source.Quantity != null));

            CreateMap<Inventory, UpdateInventoryCommandDTO>();
        }

        #endregion Constructors
    }
}