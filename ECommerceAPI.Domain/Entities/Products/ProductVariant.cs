using ECommerceAPI.Domain.Common.Abstracts;

namespace ECommerceAPI.Domain.Entities.Products
{
    public class ProductVariant : BaseEntity
    {
        #region Properties

        public string? Name { get; set; }
        public string? Value { get; set; }

        #endregion Properties

        #region Relationships

        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

        #endregion Relationships
    }
}