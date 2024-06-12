namespace ECommerceAPI.Application.DTOs.Authentication.Token
{
    public class AccessTokenDTO
    {
        public string? Token { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}