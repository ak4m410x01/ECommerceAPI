namespace ECommerceAPI.Application.Features.Product.ProductVariants.Commands.AddProductVariant.DTOs
{
    public class AddProductVariantCommandDTO
    {
        #region Properties

        public int Id { get; set; }
        public string? Product { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion Properties
    }
}