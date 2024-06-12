using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Domain.Entities.Users;
using ECommerceAPI.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ECommerceAPI.Persistence.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Constructors

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #endregion Constructors

        #region Configure Db Sets

        #region User Related Db Sets

        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserActivityLog> UserActivityLogs { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        #endregion User Related Db Sets

        #region Product Related Db Sets

        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductRecommendation> ProductRecommendations { get; set; }

        #endregion Product Related Db Sets

        #endregion Configure Db Sets

        #region On Model Creating Configuration

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Identity Configuration

            // Config Identity Tables Names
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Security");

            #endregion Identity Configuration

            #region Assemblies Configuration

            // Apply Entities Configurations
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #endregion Assemblies Configuration
        }

        #endregion On Model Creating Configuration
    }
}