namespace ECommerceAPI.Application.Features.User.Authentication.Commands.SignUp.DTOs
{
    public class SignUpCommandDTO
    {
        public bool IsAuthenticated { get; set; }
        public string? Message { get; set; }
    }
}