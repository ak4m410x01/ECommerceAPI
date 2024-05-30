using ECommerceAPI.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Persistence.EntityConfiguration.Products
{
    public class ProductRecommendationConfiguration : IEntityTypeConfiguration<ProductRecommendation>
    {
        public void Configure(EntityTypeBuilder<ProductRecommendation> builder)
        {
            #region Config Table Name
            builder.ToTable("ProductRecommendations", "Product");
            #endregion

            #region Config Relationship
            builder.HasOne(productRecommendation => productRecommendation.Product)
                   .WithMany(product => product.ProductRecommendations)
                   .HasForeignKey(productRecommendation => productRecommendation.ProductId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();
            #endregion

            #region Config Unique Constrains
            builder.HasIndex(productRecommendation => new { productRecommendation.ProductId, productRecommendation.RecommendedProductId })
                   .HasDatabaseName("ProductIdAndRecommendedProductIdIndex")
                   .IsUnique();
            #endregion
        }
    }
}
