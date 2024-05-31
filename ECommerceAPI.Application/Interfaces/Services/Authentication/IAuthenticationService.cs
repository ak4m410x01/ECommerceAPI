using ECommerceAPI.Application.DTOs.Authentication;

namespace ECommerceAPI.Application.Interfaces.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthanticationResponseDTO> SignUpAsync(SignUpDTO dto);

        Task<AuthanticationResponseDTO> SignInAsync(SignInDTO dto);
    }
}