namespace ECommerceAPI.Application.Features.User.Authentications.Queries.GetAccessToken.DTOs
{
    public class GetAccessTokenQueryDTO
    {
        #region Properties

        public string? AccessToken { get; set; }
        public DateTime? AccessTokenExpiresAt { get; set; }

        #endregion Properties
    }
}