namespace ECommerceAPI.Application.DTOs.Authentication.Token
{
    public class TokenDTO
    {
        public AccessTokenDTO? AccessToken { get; set; }
        public RefreshTokenDTO? RefreshToken { get; set; }
    }
}