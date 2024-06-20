namespace ECommerceAPI.Application.Features.Product.ProductTags.Commands.AddProductTag.DTOs
{
    public class AddProductTagCommandDTO
    {
        #region Properties

        public int Id { get; set; }
        public string? Product { get; set; }
        public string? Tag { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion Properties
    }
}