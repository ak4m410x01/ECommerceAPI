using ECommerceAPI.Application.DTOs.Authentication;

namespace ECommerceAPI.Application.Interfaces.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponseDTO> SignUpAsync(SignUpDTO dto);

        Task<AuthenticationResponseDTO> SignInAsync(SignInDTO dto);
    }
}