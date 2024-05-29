using ECommerceAPI.Domain.Enumerations.Users;
using ECommerceAPI.Domain.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Persistence.EntityConfiguration.Users
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            #region Config Table Name
            builder.ToTable("Users", "User");
            #endregion

            #region Config Properties
            builder.Property(user => user.Status)
                   .HasDefaultValue(UserStatus.Active.ToString())
                   .IsRequired();


            builder.Property(user => user.FirstName)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(user => user.LastName)
                   .HasMaxLength(100)
                   .IsRequired(false);


            builder.Property(user => user.CreatedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(user => user.ModifiedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(user => user.DeletedAt)
                   .IsRequired(false);
            #endregion
        }
    }
}
