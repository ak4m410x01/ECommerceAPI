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
            #endregion

            #region Config Properties
            builder.Property(profile => profile.Bio)
                   .IsRequired();

            builder.Property(profile => profile.ImageUrl)
                   .IsRequired(false);
            #endregion

            #region Config Relationships
            builder.HasOne(profile => profile.User)
                   .WithOne(user => user.UserProfile)
                   .IsRequired();
            #endregion
        }
    }
}
