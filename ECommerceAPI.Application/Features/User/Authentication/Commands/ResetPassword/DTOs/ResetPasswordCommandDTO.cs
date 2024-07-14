namespace ECommerceAPI.Application.Features.User.Authentication.Commands.ResetPassword.DTOs
{
    public class ResetPasswordCommandDTO
    {
        #region Properties

        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; }

        #endregion Properties
    }
}