using ECommerceAPI.Application.Features.Product.Inventories.Commands.RemoveInventory.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Inventories.Commands.RemoveInventory.Requests
{
    public class RemoveInventoryCommandRequest : IRequest<Response<RemoveInventoryCommandDTO>>
    {
        #region Properties

        public int Id { get; set; }

        #endregion Properties
    }
}