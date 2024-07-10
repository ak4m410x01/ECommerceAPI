using ECommerceAPI.Application.Features.Product.Inventories.Commands.UpdateInventory.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Inventories.Commands.UpdateInventory.Requests
{
    public class UpdateInventoryCommandRequest : IRequest<Response<UpdateInventoryCommandDTO>>
    {
        #region Properties

        public int Id { get; set; }
        public int? Quantity { get; set; }

        #endregion Properties
    }
}