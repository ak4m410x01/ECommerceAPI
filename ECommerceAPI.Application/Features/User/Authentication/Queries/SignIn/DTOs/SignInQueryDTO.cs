namespace ECommerceAPI.Application.Features.User.Authentication.Queries.SignIn.DTOs
{
    public class SignInQueryDTO
    {
        #region Properties

        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? AccessToken { get; set; }
        public DateTime AccessTokenExpiresAt { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiresAt { get; set; }

        #endregion Properties
    }
}