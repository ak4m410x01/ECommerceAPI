namespace ECommerceAPI.Application.Features.Product.Categories.Queries.GetCategoryById.DTOs
{
    public class GetCategoryByIdQueryDTO
    {
        #region Properties

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ParentCategory { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }

        #endregion Properties
    }
}