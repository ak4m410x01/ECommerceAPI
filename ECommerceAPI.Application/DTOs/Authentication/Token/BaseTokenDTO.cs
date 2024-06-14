namespace ECommerceAPI.Application.DTOs.Authentication.Token
{
    public class BaseTokenDTO
    {
        #region Properties

        public string? Token { get; set; }
        public DateTime? ExpiresAt { get; set; }

        #endregion Properties
    }
}