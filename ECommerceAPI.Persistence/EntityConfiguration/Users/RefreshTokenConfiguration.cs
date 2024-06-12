using ECommerceAPI.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceAPI.Persistence.EntityConfiguration.Users
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            #region Config Table Name

            builder.ToTable("RefreshTokens", "User");

            #endregion Config Table Name

            #region Config Properties

            builder.HasKey(token => new { token.Id, token.UserId });

            builder.Property(token => token.Token)
                   .IsRequired();

            builder.Property(token => token.ExpiresAt)
                   .IsRequired();

            builder.Property(token => token.RevokedAt)
                   .IsRequired(false);

            builder.Property(token => token.CreatedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(token => token.ModifiedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .IsRequired();

            builder.Property(token => token.DeletedAt)
                   .IsRequired(false);

            #endregion Config Properties

            #region Config Relationships

            builder.HasOne(token => token.User)
                   .WithMany(user => user.RefreshTokens)
                   .HasForeignKey(token => token.UserId)
                   .IsRequired();

            #endregion Config Relationships
        }
    }
}