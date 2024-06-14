namespace ECommerceAPI.Application.Features.User.Authentications.Queries.GetAccessToken.DTOs
{
    public class GetAccessTokenQueryDTO
    {
        #region Properties

        public string? AccessToken { get; set; }
        public string? AccessTokenExpiresAt { get; set; }

        #endregion Properties
    }
}