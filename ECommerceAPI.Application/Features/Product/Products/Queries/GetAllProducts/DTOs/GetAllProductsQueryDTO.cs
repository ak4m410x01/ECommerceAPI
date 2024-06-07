namespace ECommerceAPI.Application.Features.Product.Products.Queries.GetAllProducts.DTOs
{
    public class GetAllProductsQueryDTO
    {
        #region Properties

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SKU { get; set; }
        public decimal Price { get; set; }

        #endregion Properties
    }
}