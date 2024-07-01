namespace ECommerceAPI.Application.Features.User.Authentication.Commands.GetRefreshToken.DTOs
{
    public class GetRefreshTokenCommandDTO
    {
        #region Properties

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiresAt { get; set; }

        #endregion Properties
    }
}