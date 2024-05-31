using ECommerceAPI.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Persistence.EntityConfiguration.Products
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            #region Config Table Name

            builder.ToTable("Tags", "Product");

            #endregion Config Table Name

            #region Properties

            builder.Property(tag => tag.Name)
                   .IsRequired();

            builder.Property(tag => tag.CreatedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(tag => tag.ModifiedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(tag => tag.DeletedAt)
                   .IsRequired(false);

            #endregion Properties

            #region Config Unique Constrains

            builder.HasIndex(tag => tag.Name)
                   .IsUnique();

            #endregion Config Unique Constrains
        }
    }
}