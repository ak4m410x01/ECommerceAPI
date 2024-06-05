using ECommerceAPI.Shared.Responses;
using System.Net;

namespace ECommerceAPI.Shared.Exceptions
{
    public class ServerErrorException : Response<ServerErrorException>
    {
        #region Properties

        public string Details { get; set; } = string.Empty;

        #endregion Properties

        #region Constructors

        public ServerErrorException()
        {
            Message = "Internal Server Error";
            StatusCode = HttpStatusCode.InternalServerError;
            Succeeded = false;
        }

        #endregion Constructors
    }
}