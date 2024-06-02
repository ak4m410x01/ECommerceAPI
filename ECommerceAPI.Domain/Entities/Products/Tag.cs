using ECommerceAPI.Domain.Common.Abstracts;

namespace ECommerceAPI.Domain.Entities.Products
{
    public class Tag : BaseEntity
    {
        #region Properties

        public string? Name { get; set; }

        #endregion Properties

        #region Relationships

        public virtual ICollection<ProductTag>? ProductTags { get; set; } = new List<ProductTag>();

        #endregion Relationships
    }
}