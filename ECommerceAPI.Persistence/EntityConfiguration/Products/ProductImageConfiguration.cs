using ECommerceAPI.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Persistence.EntityConfiguration.Products
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            #region Config Table Name

            builder.ToTable("ProductImages", "Product");

            #endregion Config Table Name

            #region Config Properties

            builder.Property(productImage => productImage.Url)
                   .IsRequired();

            builder.Property(productImage => productImage.CreatedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(productImage => productImage.ModifiedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(productImage => productImage.DeletedAt)
                   .IsRequired(false);

            #endregion Config Properties

            #region Config Relationship

            builder.HasOne(productImage => productImage.Product)
                   .WithMany(product => product.ProductImages)
                   .HasForeignKey(productImage => productImage.ProductId)
                   .IsRequired();

            #endregion Config Relationship
        }
    }
}