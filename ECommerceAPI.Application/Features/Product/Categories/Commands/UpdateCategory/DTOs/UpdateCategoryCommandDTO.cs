namespace ECommerceAPI.Application.Features.Product.Categories.Commands.UpdateCategory.DTOs
{
    public class UpdateCategoryCommandDTO
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? ParentCategory { get; set; }

        #endregion Properties
    }
}