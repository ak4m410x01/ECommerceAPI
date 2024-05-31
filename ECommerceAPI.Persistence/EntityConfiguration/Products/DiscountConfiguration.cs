using ECommerceAPI.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Persistence.EntityConfiguration.Products
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            #region Config Table Name

            builder.ToTable("Discounts", "Product");

            #endregion Config Table Name

            #region Config Properties

            builder.Property(discount => discount.Code)
                   .IsRequired();

            builder.Property(discount => discount.Description)
                   .IsRequired(false);

            builder.Property(discount => discount.Percent)
                   .HasColumnType("DECIMAL(15, 3)")
                   .IsRequired();

            builder.Property(discount => discount.UsedTimes)
                   .HasDefaultValue(0)
                   .IsRequired();

            builder.Property(discount => discount.MaxUses)
                   .IsRequired();

            builder.Property(discount => discount.StartAt)
                   .IsRequired();

            builder.Property(discount => discount.EndAt)
                   .IsRequired();

            builder.Property(discount => discount.CreatedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(discount => discount.ModifiedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(discount => discount.DeletedAt)
                   .IsRequired(false);

            #endregion Config Properties

            #region Config Unique Constrains

            builder.HasIndex(discount => discount.Code)
                   .IsUnique();

            #endregion Config Unique Constrains
        }
    }
}