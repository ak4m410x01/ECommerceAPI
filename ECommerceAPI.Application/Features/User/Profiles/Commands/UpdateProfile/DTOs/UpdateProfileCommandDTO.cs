namespace ECommerceAPI.Application.Features.User.Profiles.Commands.UpdateProfile.DTOs
{
    public class UpdateProfileCommandDTO
    {
        #region Properties

        public string? Email { get; set; }
        public string? Username { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Bio { get; set; }

        public DateTime CreatedAt { get; set; }

        #endregion Properties
    }
}