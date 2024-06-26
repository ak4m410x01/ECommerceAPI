﻿using ECommerceAPI.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Persistence.EntityConfiguration.Products
{
    public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
    {
        public void Configure(EntityTypeBuilder<ProductTag> builder)
        {
            #region Config Table Name

            builder.ToTable("ProductTags", "Product");

            #endregion Config Table Name

            #region Config Primary Key

            builder.HasKey(productTag => new { productTag.ProductId, productTag.TagId });

            #endregion Config Primary Key

            #region Config Relationship

            builder.HasOne(productTag => productTag.Product)
                   .WithMany(product => product.ProductTags)
                   .HasForeignKey(productTag => productTag.ProductId)
                   .IsRequired();

            builder.HasOne(productTag => productTag.Tag)
                   .WithMany(tag => tag.ProductTags)
                   .HasForeignKey(productTag => productTag.TagId)
                   .IsRequired();

            #endregion Config Relationship

            #region Config Unique Constrains

            builder.HasIndex(productTag => new { productTag.ProductId, productTag.TagId })
                   .IsUnique();

            #endregion Config Unique Constrains
        }
    }
}