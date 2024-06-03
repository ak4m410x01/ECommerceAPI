using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Application.DTOs.Authentication
{
    public class SignInDTO
    {
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;
    }
}