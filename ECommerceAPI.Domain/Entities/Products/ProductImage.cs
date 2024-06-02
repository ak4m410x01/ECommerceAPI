using ECommerceAPI.Domain.Common.Abstracts;

namespace ECommerceAPI.Domain.Entities.Products
{
    public class ProductImage : BaseEntity
    {
        #region Properties

        public string? Url { get; set; }

        #endregion Properties

        #region Relationships

        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

        #endregion Relationships
    }
}