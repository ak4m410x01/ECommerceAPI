using ECommerceAPI.Application.DTOs.Authentication.ConfirmEmail;
using ECommerceAPI.Application.DTOs.Authentication.ForgetPassword;
using ECommerceAPI.Application.DTOs.Authentication.ResetPassword;
using ECommerceAPI.Application.DTOs.Authentication.SignIn;
using ECommerceAPI.Application.DTOs.Authentication.SignUp;
using ECommerceAPI.Application.DTOs.Authentication.Token;

namespace ECommerceAPI.Application.Interfaces.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<SignUpDTOResponse> SignUpAsync(SignUpDTORequest request);

        Task<SignInDTOResponse> SignInAsync(SignInDTORequest request);

        Task<AccessTokenDTO> GetAccessTokenAsync(string refreshToken);

        Task<RefreshTokenDTO> GetRefreshTokenAsync(string refreshToken);

        Task<ConfirmEmailDTOResponse> ConfirmEmailAsync(ConfirmEmailDTORequest request);

        Task<ForgetPasswordDTOResponse> ForgetPasswordAsync(ForgetPasswordDTORequest request);

        Task<ResetPasswordDTOResponse> ResetPasswordAsync(ResetPasswordDTORequest request);
    }
}