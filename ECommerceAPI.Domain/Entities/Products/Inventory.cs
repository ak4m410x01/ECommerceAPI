using ECommerceAPI.Domain.Common.Abstracts;

namespace ECommerceAPI.Domain.Entities.Products
{
    public class Inventory : BaseEntity
    {
        #region Properties

        public int Quantity { get; set; }

        #endregion Properties

        #region Relationships

        public ICollection<Product> Products { get; set; } = new List<Product>();

        #endregion Relationships
    }
}