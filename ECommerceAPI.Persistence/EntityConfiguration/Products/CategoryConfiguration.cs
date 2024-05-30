using ECommerceAPI.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Persistence.EntityConfiguration.Products
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            #region Config Table Name
            builder.ToTable("Categories", "Product");
            #endregion

            #region Config Properties
            builder.Property(category => category.Name)
                   .IsRequired();

            builder.Property(category => category.Description)
                   .IsRequired(false);
            #endregion

            #region Config Relationship
            builder.HasOne(child => child.ParentCategory)
                   .WithMany(parent => parent.ChildCategories)
                   .HasForeignKey(child => child.ParentCategoryId)
                   .IsRequired(false);
            #endregion
        }
    }
}
