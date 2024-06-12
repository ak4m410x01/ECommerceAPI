namespace ECommerceAPI.Application.DTOs.Authentication.Token
{
    public class RefreshTokenDTO
    {
        public string? Token { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}