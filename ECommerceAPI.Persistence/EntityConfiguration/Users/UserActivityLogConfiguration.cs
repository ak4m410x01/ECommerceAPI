using ECommerceAPI.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Persistence.EntityConfiguration.Users
{
    public class UserActivityLogConfiguration : IEntityTypeConfiguration<UserActivityLog>
    {
        public void Configure(EntityTypeBuilder<UserActivityLog> builder)
        {
            #region Config Table Name
            builder.ToTable("UserActivityLogs", "User");
            #endregion

            #region Config Properties
            builder.Property(log => log.Action)
                   .IsRequired();

            builder.Property(log => log.Description)
                   .IsRequired(false);
            #endregion

            #region Config Relationships
            builder.HasOne(log => log.User)
                   .WithMany(user => user.UserActivityLogs)
                   .HasForeignKey(log => log.UserId)
                   .IsRequired();
            #endregion
        }
    }
}
