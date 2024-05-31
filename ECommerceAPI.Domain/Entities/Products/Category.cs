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

        public int ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
        public ICollection<Category> ChildCategories { get; set; } = new List<Category>();

        public ICollection<Product> Products { get; set; } = new List<Product>();

        #endregion Relationships
    }
}