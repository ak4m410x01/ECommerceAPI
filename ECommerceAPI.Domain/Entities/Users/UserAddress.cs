using ECommerceAPI.Domain.Common.Abstracts;
using ECommerceAPI.Domain.IdentityEntities;

namespace ECommerceAPI.Domain.Entities.Users
{
    public class UserAddress : BaseEntity
    {
        #region Properties
        public string? PostalCode { get; set; }
        public string? Address { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        #endregion

        #region Relationships
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        #endregion
    }
}
