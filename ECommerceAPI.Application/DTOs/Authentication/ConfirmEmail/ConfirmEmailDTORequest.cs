namespace ECommerceAPI.Application.DTOs.Authentication.ConfirmEmail
{
    public class ConfirmEmailDTORequest
    {
        #region Properties

        public string UserId { get; set; } = default!;
        public string Token { get; set; } = default!;

        #endregion Properties
    }
}