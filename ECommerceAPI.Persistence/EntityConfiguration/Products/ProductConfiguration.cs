using ECommerceAPI.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Persistence.EntityConfiguration.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            #region Config Table Name

            builder.ToTable("Products", "Product");

            #endregion Config Table Name

            #region Properties

            builder.Property(product => product.Name)
                   .IsRequired();

            builder.Property(product => product.Description)
                   .IsRequired(false);

            builder.Property(product => product.SKU)
                   .IsRequired();

            builder.Property(product => product.Price)
                   .HasColumnType("DECIMAL(15, 3)")
                   .IsRequired();

            builder.Property(product => product.CreatedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(product => product.ModifiedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(product => product.DeletedAt)
                   .IsRequired(false);

            #endregion Properties

            #region Relationships

            builder.HasOne(product => product.Category)
                   .WithMany(category => category.Products)
                   .HasForeignKey(product => product.CategoryId)
                   .IsRequired();

            builder.HasOne(product => product.Inventory)
                   .WithMany(inventory => inventory.Products)
                   .HasForeignKey(product => product.InventoryId)
                   .IsRequired();

            builder.HasOne(product => product.Discount)
                   .WithMany(discount => discount.Products)
                   .HasForeignKey(product => product.DiscountId)
                   .IsRequired();

            #endregion Relationships

            #region Config Unique Constrains

            builder.HasIndex(product => product.SKU)
                   .HasDatabaseName("SKUIndex")
                   .IsUnique();

            #endregion Config Unique Constrains
        }
    }
}