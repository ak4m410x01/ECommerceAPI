using ECommerceAPI.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Persistence.EntityConfiguration.Products
{
    internal class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            #region Config Table Name
            builder.ToTable("ProductVariants", "Product");
            #endregion

            #region Properties
            builder.Property(productVariant => productVariant.Name)
                   .IsRequired();

            builder.Property(productVariant => productVariant.Value)
                   .IsRequired();

            builder.Property(productVariant => productVariant.CreatedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(productVariant => productVariant.ModifiedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(productVariant => productVariant.DeletedAt)
                   .IsRequired(false);
            #endregion

            #region Config Relationship
            builder.HasOne(productVariant => productVariant.Product)
                   .WithMany(product => product.ProductVariants)
                   .HasForeignKey(productVariant => productVariant.ProductId)
                   .IsRequired();
            #endregion

            #region Config Unique Constrains
            builder.HasIndex(productVariant => productVariant.Name)
                   .IsUnique();
            #endregion
        }
    }
}
