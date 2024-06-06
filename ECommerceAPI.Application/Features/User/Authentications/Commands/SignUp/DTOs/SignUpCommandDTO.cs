namespace ECommerceAPI.Application.Features.User.Authentications.Commands.SignUp.DTOs
{
    public class SignUpCommandDTO
    {
        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; }

        public string? AccessToken { get; set; }
        public DateTime? AccessTokenValidTo { get; set; }
    }
}