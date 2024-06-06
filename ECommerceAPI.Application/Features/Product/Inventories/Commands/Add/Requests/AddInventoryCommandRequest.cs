using ECommerceAPI.Application.Features.Product.Inventories.Commands.Add.DTOs;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Inventories.Commands.Add.Requests
{
    public class AddInventoryCommandRequest : IRequest<Response<AddInventoryCommandDTO>>
    {
        public int Quantity { get; set; } = 1;
    }
}