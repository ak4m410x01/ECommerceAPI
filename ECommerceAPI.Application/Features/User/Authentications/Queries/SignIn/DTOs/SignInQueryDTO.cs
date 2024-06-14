namespace ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.DTOs
{
    public class SignInQueryDTO
    {
        #region Properties

        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? AccessToken { get; set; }
        public string? AccessTokenExpiresAt { get; set; }
        public string? RefreshToken { get; set; }
        public string? RefreshTokenExpiresAt { get; set; }

        #endregion Properties
    }
}