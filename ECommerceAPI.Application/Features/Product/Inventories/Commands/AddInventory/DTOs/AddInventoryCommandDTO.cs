namespace ECommerceAPI.Application.Features.Product.Inventories.Commands.AddInventory.DTOs
{
    public class AddInventoryCommandDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}