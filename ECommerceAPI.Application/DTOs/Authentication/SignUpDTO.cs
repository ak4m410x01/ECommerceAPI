namespace ECommerceAPI.Application.DTOs.Authentication
{
    public class SignUpDTO
    {
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
    }
}