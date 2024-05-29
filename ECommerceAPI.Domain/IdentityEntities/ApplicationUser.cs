using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Domain.IdentityEntities
{
    public class ApplicationUser : IdentityUser
    {
        #region Properties
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Status { get; set; }

        public DateTime CreatedAt { get; }
        public DateTime ModifiedAt { get; }
        public DateTime? DeletedAt { get; }
        #endregion
    }
}
