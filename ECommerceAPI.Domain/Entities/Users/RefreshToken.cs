using ECommerceAPI.Domain.Common.Abstracts;
using ECommerceAPI.Domain.IdentityEntities;

namespace ECommerceAPI.Domain.Entities.Users
{
    public class RefreshToken : BaseEntity
    {
        #region Properties

        public string? Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsExpired { get; private set; }
        public DateTime? RevokedAt { get; set; }

        public bool IsActive { get; private set; }

        #endregion Properties

        #region Relationships

        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        #endregion Relationships
    }
}