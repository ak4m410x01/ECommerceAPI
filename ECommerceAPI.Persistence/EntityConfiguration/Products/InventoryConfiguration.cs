using ECommerceAPI.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Persistence.EntityConfiguration.Products
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            #region Config Table Name
            builder.ToTable("Inventories", "Product");
            #endregion

            #region Config Properties
            builder.Property(inventory => inventory.Quantity)
                   .IsRequired();

            builder.Property(inventory => inventory.CreatedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(inventory => inventory.ModifiedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(inventory => inventory.DeletedAt)
                   .IsRequired(false);
            #endregion
        }
    }
}
