using ECommerceAPI.Shared.Responses;
using System.Net;

namespace ECommerceAPI.Shared.Exceptions.ServerError
{
    public class ServerErrorExceptionResponse : Response<ServerErrorExceptionResponse>
    {
        #region Properties

        public string Details { get; set; } = string.Empty;

        #endregion Properties

        #region Constructors

        public ServerErrorExceptionResponse()
        {
            Message = "Internal Server Error";
            StatusCode = HttpStatusCode.InternalServerError;
            Succeeded = false;
        }

        #endregion Constructors
    }
}