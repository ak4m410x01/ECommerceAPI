using ECommerceAPI.Shared.Responses;
using System.Net;

namespace ECommerceAPI.Shared.Exceptions
{
    public class ValidationErrorException : Response<ValidationErrorException>
    {
        #region Constructors

        public ValidationErrorException()
        {
            Message = "Bad Request";
            StatusCode = HttpStatusCode.BadRequest;
            Succeeded = false;
            Errors = new List<string>();
        }

        #endregion Constructors
    }
}