namespace ECommerceAPI.Application.Features.Product.Categories.Commands.Add.DTOs
{
    public class AddCategoryCommandDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ParentCategory { get; set; }
        public string? Description { get; set; }
    }
}