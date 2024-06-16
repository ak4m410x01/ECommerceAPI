using ECommerceAPI.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Persistence.EntityConfiguration.Users
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            #region Config Table Name

            builder.ToTable("Profiles", "User");

            #endregion Config Table Name

            #region Config Properties

            builder.Property(profile => profile.Bio)
                   .IsRequired();

            builder.Property(profile => profile.ImageUrl)
                   .IsRequired(false);

            builder.Property(user => user.CreatedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(user => user.ModifiedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(user => user.DeletedAt)
                   .IsRequired(false);

            #endregion Config Properties

            #region Config Relationships

            builder.HasOne(profile => profile.User)
                   .WithOne(user => user.UserProfile)
                   .IsRequired();

            #endregion Config Relationships
        }
    }
}