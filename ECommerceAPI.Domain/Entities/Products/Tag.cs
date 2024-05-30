using ECommerceAPI.Domain.Common.Abstracts;

namespace ECommerceAPI.Domain.Entities.Products
{
    public class Tag : BaseEntity
    {
        #region Properties
        public string? Name { get; set; }
        #endregion

        #region Relationships
        public ICollection<ProductTag>? ProductTags { get; set; } = new List<ProductTag>();
        #endregion
    }
}
