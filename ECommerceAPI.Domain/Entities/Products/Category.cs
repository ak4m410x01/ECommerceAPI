using ECommerceAPI.Domain.Common.Abstracts;

namespace ECommerceAPI.Domain.Entities.Products
{
    public class Category : BaseEntity
    {
        #region Properties

        public string? Name { get; set; }
        public string? Description { get; set; }

        #endregion Properties

        #region Relationships

        public int? ParentCategoryId { get; set; }
        public virtual Category? ParentCategory { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; } = new List<Category>();

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        #endregion Relationships
    }
}