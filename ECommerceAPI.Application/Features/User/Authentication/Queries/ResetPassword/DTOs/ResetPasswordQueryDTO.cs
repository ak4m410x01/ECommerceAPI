namespace ECommerceAPI.Application.Features.User.Authentication.Queries.ResetPassword.DTOs
{
    public class ResetPasswordQueryDTO
    {
        #region Properties

        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; }

        #endregion Properties
    }
}