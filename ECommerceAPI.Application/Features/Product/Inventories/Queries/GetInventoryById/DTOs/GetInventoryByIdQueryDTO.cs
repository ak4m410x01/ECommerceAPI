namespace ECommerceAPI.Application.Features.Product.Inventories.Queries.GetInventoryById.DTOs
{
    public class GetInventoryByIdQueryDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}