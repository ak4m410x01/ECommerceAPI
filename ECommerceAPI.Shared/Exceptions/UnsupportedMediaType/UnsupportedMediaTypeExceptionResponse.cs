using ECommerceAPI.Shared.Responses;
using System.Net;

namespace ECommerceAPI.Shared.Exceptions.UnsupportedMediaType
{
    public class UnsupportedMediaTypeExceptionResponse : Response<UnsupportedMediaTypeExceptionResponse>
    {
        #region Properties

        public string Details { get; set; } = string.Empty;

        #endregion Properties

        #region Constructors

        public UnsupportedMediaTypeExceptionResponse()
        {
            Message = "Unsupported Media Type";
            StatusCode = HttpStatusCode.UnsupportedMediaType;
            Succeeded = false;
        }

        #endregion Constructors
    }
}