using ECommerceAPI.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Persistence.EntityConfiguration.Users
{
    public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            #region Config Table Name
            builder.ToTable("UserAddresses", "User");
            #endregion

            #region Config Properties
            builder.Property(address => address.PostalCode)
                   .HasMaxLength(256)
                   .IsRequired();

            builder.Property(address => address.Address)
                   .HasMaxLength(256)
                   .IsRequired();

            builder.Property(address => address.Street)
                   .HasMaxLength(256)
                   .IsRequired();

            builder.Property(address => address.City)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(address => address.Country)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(user => user.CreatedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(user => user.ModifiedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(user => user.DeletedAt)
                   .IsRequired(false);
            #endregion

            #region Config Relationships
            builder.HasOne(address => address.User)
                   .WithMany(user => user.Addresses)
                   .HasForeignKey(address => address.UserId)
                   .IsRequired();
            #endregion
        }
    }
}
