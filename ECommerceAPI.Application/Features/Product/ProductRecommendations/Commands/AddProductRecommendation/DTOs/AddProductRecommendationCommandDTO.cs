namespace ECommerceAPI.Application.Features.Product.ProductRecommendations.Commands.AddProductRecommendation.DTOs
{
    public class AddProductRecommendationCommandDTO
    {
        #region Properties

        public string? Product { get; set; }
        public string? RecommendedProduct { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion Properties
    }
}