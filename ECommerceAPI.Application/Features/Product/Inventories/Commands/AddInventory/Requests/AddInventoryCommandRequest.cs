using ECommerceAPI.Application.Features.Product.Inventories.Commands.AddInventory.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Inventories.Commands.AddInventory.Requests
{
    public class AddInventoryCommandRequest : IRequest<Response<AddInventoryCommandDTO>>
    {
        public int Quantity { get; set; } = 1;
    }
}