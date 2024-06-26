using System.Net;

namespace ECommerceAPI.Shared.Responses
{
    public class ResponseHandler
    {
        #region Constructors

        public ResponseHandler()
        {
        }

        #endregion Constructors

        #region Methods

        public Response<T> Removed<T>(string? message = null)
        {
            return new Response<T>()
            {
                Message = message is null ? "Removed Successfully" : message,
                StatusCode = HttpStatusCode.NoContent,
                Succeeded = true
            };
        }

        public Response<T> Unauthorized<T>(string? message = null)
        {
            return new Response<T>()
            {
                Message = message is null ? "Unauthorized" : message,
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = false
            };
        }

        public Response<T> Forbidden<T>(string? message = null)
        {
            return new Response<T>()
            {
                Message = message is null ? "Forbidden" : message,
                StatusCode = HttpStatusCode.Forbidden,
                Succeeded = false
            };
        }

        public Response<T> BadRequest<T>(string? message = null)
        {
            return new Response<T>()
            {
                Message = message is null ? "Bad Request" : message,
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false
            };
        }

        public Response<T> NotFound<T>(string? message = null)
        {
            return new Response<T>()
            {
                Message = message is null ? "Not Found" : message,
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false
            };
        }

        public Response<T> ServerError<T>(string? message = null)
        {
            return new Response<T>()
            {
                Message = message is null ? "Internal Server Error" : message,
                StatusCode = HttpStatusCode.InternalServerError,
                Succeeded = false
            };
        }

        public Response<T> Success<T>(T data, string? message = null)
        {
            return new Response<T>()
            {
                Message = message is null ? "Success" : message,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Data = data
            };
        }

        public Response<T> Success<T>(string? message = null)
        {
            return new Response<T>()
            {
                Message = message is null ? "Success" : message,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
            };
        }

        public Response<T> Created<T>(T data, string? message = null)
        {
            return new Response<T>()
            {
                Message = message is null ? "Created Successfully" : message,
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Data = data
            };
        }

        #endregion Methods
    }
}