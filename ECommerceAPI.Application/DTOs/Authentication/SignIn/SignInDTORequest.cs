namespace ECommerceAPI.Application.DTOs.Authentication.SignIn
{
    public class SignInDTORequest
    {
        #region Properties

        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;

        #endregion Properties
    }
}