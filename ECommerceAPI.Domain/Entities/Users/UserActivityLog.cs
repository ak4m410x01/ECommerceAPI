using ECommerceAPI.Domain.Common.Abstracts;
using ECommerceAPI.Domain.IdentityEntities;

namespace ECommerceAPI.Domain.Entities.Users
{
    public class UserActivityLog : BaseEntity
    {
        #region Properties

        public string? Action { get; set; }
        public string? Description { get; set; }

        #endregion Properties

        #region Relationships

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        #endregion Relationships
    }
}