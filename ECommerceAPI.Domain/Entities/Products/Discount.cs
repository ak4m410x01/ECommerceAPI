using ECommerceAPI.Domain.Common.Abstracts;

namespace ECommerceAPI.Domain.Entities.Products
{
    public class Discount : BaseEntity
    {
        #region Properties
        public string? Code { get; set; }
        public string? Description { get; set; }
        public decimal Percent { get; set; }
        public int UsedTimes { get; set; }
        public int MaxUses { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        #endregion

        #region Relationships
        public ICollection<Product> Products { get; set; } = new List<Product>();
        #endregion
    }
}
