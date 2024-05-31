using ECommerceAPI.Domain.Common.Abstracts;
using ECommerceAPI.Domain.IdentityEntities;

namespace ECommerceAPI.Domain.Entities.Users
{
    public class UserProfile : BaseEntity
    {
        #region Properties

        public string? Bio { get; set; }
        public string? ImageUrl { get; set; }

        #endregion Properties

        #region Relationships

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        #endregion Relationships
    }
}