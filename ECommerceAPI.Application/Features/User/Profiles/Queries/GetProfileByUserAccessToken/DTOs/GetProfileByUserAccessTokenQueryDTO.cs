namespace ECommerceAPI.Application.Features.User.Profiles.Queries.GetProfileByUserAccessToken.DTOs
{
    public class GetProfileByUserAccessTokenQueryDTO
    {
        #region Properties

        public string? Email { get; set; }
        public string? Username { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Bio { get; set; }
        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        #endregion Properties
    }
}