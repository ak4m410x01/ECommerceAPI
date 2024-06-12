using ECommerceAPI.Application.DTOs.Authentication.Token;

namespace ECommerceAPI.Application.DTOs.Authentication
{
    public class AuthenticationResponseDTO
    {
        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; }

        public TokenDTO Token { get; set; }
    }
}