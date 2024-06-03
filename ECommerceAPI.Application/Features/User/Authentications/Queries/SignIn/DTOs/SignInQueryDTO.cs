namespace ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.DTOs
{
    public class SignInQueryDTO
    {
        public string Message { get; set; } = string.Empty;
        public bool IsAuthenticated { get; set; }

        public string? UserId { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }

        public IList<string>? Roles { get; set; }

        public string? AccessToken { get; set; }
        public DateTime? AccessTokenValidTo { get; set; }
    }
}