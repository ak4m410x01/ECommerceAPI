namespace ECommerceAPI.Application.DTOs.Authentication
{
    public class AuthenticationResponseDTO
    {
        public string Message { get; set; } = string.Empty;
        public bool IsAuthenticated { get; set; }

        public string? UserId { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }

        public string? AccessToken { get; set; }
        public DateTime? AccessTokenExpiration { get; set; }
    }
}