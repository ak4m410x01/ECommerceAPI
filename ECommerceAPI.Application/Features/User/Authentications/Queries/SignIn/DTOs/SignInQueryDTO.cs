namespace ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.DTOs
{
    public class SignInQueryDTO
    {
        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; }

        public string? AccessToken { get; set; }
        public DateTime? AccessTokenValidTo { get; set; }
    }
}