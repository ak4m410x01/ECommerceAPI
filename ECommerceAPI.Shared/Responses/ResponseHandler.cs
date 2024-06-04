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

        public Response<T> Deleted<T>()
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.NoContent,
                Succeeded = true,
                Message = "Deleted Successfully"
            };
        }

        public Response<T> Unauthorized<T>(string? message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = false,
                Message = message is null ? "Unauthorized" : message,
            };
        }

        public Response<T> BadRequest<T>(string? message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = message is null ? "Bad Request" : message
            };
        }

        public Response<T> NotFound<T>(string? message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message is null ? "Not Found" : message
            };
        }

        public Response<T> Success<T>(T data, string message = "", object? meta = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = message,
                Data = data,
            };
        }

        public Response<T> Created<T>(T data, object? meta = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created Successfully",
                Data = data,
                Meta = meta
            };
        }

        #endregion Methods
    }
}