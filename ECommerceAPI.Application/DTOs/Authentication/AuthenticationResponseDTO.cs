namespace ECommerceAPI.Application.DTOs.Authentication
{
    public class AuthenticationResponseDTO
    {
        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; }

        public string? AccessToken { get; set; }
        public DateTime? AccessTokenValidTo { get; set; }
    }
}