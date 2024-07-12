namespace ECommerceAPI.Application.Features.User.Authentication.Commands.ConfirmEmail.DTOs
{
    public class ConfirmEmailCommandDTO
    {
        #region Properties

        public bool IsAuthenticated { get; set; }
        public string? Message { get; set; }

        #endregion Properties
    }
}