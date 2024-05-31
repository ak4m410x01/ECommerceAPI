using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Application.DTOs.Authentication
{
    public class SignUpDTO
    {
        [Required(ErrorMessage = "The Email field is required.")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "The Username field is required.")]
        public string UserName { get; set; } = default!;

        [Required(ErrorMessage = "The Password field is required.")]
        public string Password { get; set; } = default!;

        [Required(ErrorMessage = "The ConfirmPassword field is required.")]
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; } = default!;
    }
}