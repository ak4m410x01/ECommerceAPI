namespace ECommerceAPI.Application.Features.Product.Inventories.Commands.Add.DTOs
{
    public class AddInventoryCommandDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}