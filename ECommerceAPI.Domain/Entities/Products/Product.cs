using ECommerceAPI.Domain.Common.Abstracts;

namespace ECommerceAPI.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        #region Properties

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? SKU { get; set; }
        public decimal Price { get; set; }

        #endregion Properties

        #region Relationships

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int InventoryId { get; set; }
        public Inventory? Inventory { get; set; }

        public int DiscountId { get; set; }
        public Discount? Discount { get; set; }

        public ICollection<ProductImage>? ProductImages { get; set; } = new List<ProductImage>();
        public ICollection<ProductTag>? ProductTags { get; set; } = new List<ProductTag>();
        public ICollection<ProductVariant>? ProductVariants { get; set; } = new List<ProductVariant>();
        public ICollection<ProductRecommendation>? ProductRecommendations { get; set; } = new List<ProductRecommendation>();

        #endregion Relationships
    }
}