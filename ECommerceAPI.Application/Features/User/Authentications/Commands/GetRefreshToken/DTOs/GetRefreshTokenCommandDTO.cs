namespace ECommerceAPI.Application.Features.User.Authentications.Commands.GetRefreshToken.DTOs
{
    public class GetRefreshTokenCommandDTO
    {
        #region Properties

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiresAt { get; set; }

        #endregion Properties
    }
}