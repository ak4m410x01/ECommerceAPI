using ECommerceAPI.Shared.Responses;
using System.Net;

namespace ECommerceAPI.Shared.Exceptions
{
    public class ValidationErrorException : Response<ValidationErrorException>
    {
        public List<string> Errors { get; set; }

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