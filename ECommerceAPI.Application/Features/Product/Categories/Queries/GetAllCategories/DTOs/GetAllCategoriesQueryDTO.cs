namespace ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.DTOs
{
    public class GetAllCategoriesQueryDTO
    {
        #region Properties

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ParentCategory { get; set; }

        #endregion Properties
    }
}