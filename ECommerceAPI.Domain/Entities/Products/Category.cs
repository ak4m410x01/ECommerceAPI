using ECommerceAPI.Domain.Common.Abstracts;

namespace ECommerceAPI.Domain.Entities.Products
{
    public class Category : BaseEntity
    {
        #region Properties
        public string? Name { get; set; }
        public string? Description { get; set; }
        #endregion

        #region Relationships
        public int ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
        public ICollection<Category> ChildCategories { get; set; } = new List<Category>();
        #endregion
    }
}
