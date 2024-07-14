namespace ECommerceAPI.Application.DTOs.Authentication.ResetPassword
{
    public class ResetPasswordDTORequest
    {
        #region Properties

        public string UserId { get; set; } = default!;
        public string Token { get; set; } = default!;
        public string NewPassword { get; set; } = default!;
        public string ConfirmNewPassword { get; set; } = default!;

        #endregion Properties
    }
}