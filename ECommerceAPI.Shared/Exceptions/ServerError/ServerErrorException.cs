namespace ECommerceAPI.Shared.Exceptions.ServerError;

public class ServerErrorException : Exception
{
    #region Constructors

    public ServerErrorException(string? message):base(message)
    {
            
    }
        
    #endregion
}