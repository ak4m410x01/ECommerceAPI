using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Application.DTOs.Authentication
{
    public class SignInDTO
    {
        [Required(ErrorMessage = "The Email field is required.")]
        public string Email { get; set; } = default!;
        [Required(ErrorMessage = "The Password field is required.")]
        public string Password { get; set; } = default!;
    }
}
