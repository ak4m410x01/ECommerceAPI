namespace ECommerceAPI.Shared.Exceptions.ValidationError;

public class ValidationErrorException : Exception
{
    #region Constructors

    public ValidationErrorException(string? message): base(message)
    {
    }

    #endregion
}