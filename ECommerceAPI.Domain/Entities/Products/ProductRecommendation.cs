using ECommerceAPI.Domain.Common.Abstracts;

namespace ECommerceAPI.Domain.Entities.Products
{
    public class ProductRecommendation : BaseEntity
    {
        #region Relationships
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int RecommendedProductId { get; set; }
        public Product? RecommendedProduct { get; set; }
        #endregion
    }
}
