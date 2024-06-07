namespace ECommerceAPI.Application.Features.Product.Categories.Commands.AddCategory.DTOs
{
    public class AddCategoryCommandDTO
    {
        #region Properties

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ParentCategory { get; set; }
        public string? Description { get; set; }

        #endregion Properties
    }
}