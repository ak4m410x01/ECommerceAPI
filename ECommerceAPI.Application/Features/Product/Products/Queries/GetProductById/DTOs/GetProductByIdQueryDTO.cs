namespace ECommerceAPI.Application.Features.Product.Products.Queries.GetProductById.DTOs
{
    public class GetProductByIdQueryDTO
    {
        #region Properties

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? SKU { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public int Inventory { get; set; }
        public string? Discount { get; set; }

        #endregion Properties
    }
}