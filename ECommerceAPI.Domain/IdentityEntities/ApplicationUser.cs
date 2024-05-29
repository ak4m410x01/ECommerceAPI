using ECommerceAPI.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Domain.IdentityEntities
{
    public class ApplicationUser : IdentityUser
    {
        #region Properties
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        #endregion

        #region Relationships
        public ICollection<UserAddress> Addresses { get; set; } = new List<UserAddress>();
        #endregion
    }
}
