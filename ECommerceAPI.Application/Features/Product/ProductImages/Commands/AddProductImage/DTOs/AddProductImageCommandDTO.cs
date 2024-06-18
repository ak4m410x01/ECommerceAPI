namespace ECommerceAPI.Application.Features.Product.ProductImages.Commands.AddProductImage.DTOs
{
    public class AddProductImageCommandDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? Url { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}