using ECommerceAPI.Shared.Responses;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ECommerceAPI.Presentation.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        #region Properties

        private readonly RequestDelegate _next;

        #endregion Properties

        #region Constructors

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion Constructors

        #region Methods

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Validate Content-Type header for POST and PUT requests
                if (context.Request.Method == HttpMethods.Post || context.Request.Method == HttpMethods.Put)
                {
                    if (!context.Request.Headers.ContainsKey("Content-Type") ||
                        !IsValidContentType(context.Request.Headers["Content-Type"]!))
                    {
                        var responseModel = new Response<string>
                        {
                            Succeeded = false,
                            Message = "Unsupported Media Type",
                            StatusCode = HttpStatusCode.UnsupportedMediaType
                        };

                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = (int)HttpStatusCode.UnsupportedMediaType;
                        await context.Response.WriteAsJsonAsync(responseModel);
                        return;
                    }
                }

                await _next.Invoke(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };

                switch (error)
                {
                    case UnauthorizedAccessException e:
                        responseModel.Message = error.Message;
                        responseModel.StatusCode = HttpStatusCode.Unauthorized;
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;

                    case ValidationException e:
                        responseModel.Message = error.Message;
                        responseModel.StatusCode = HttpStatusCode.UnprocessableEntity;
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        break;

                    case KeyNotFoundException e:
                        responseModel.Message = error.Message;
                        responseModel.StatusCode = HttpStatusCode.NotFound;
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case DbUpdateException e:
                        responseModel.Message = e.Message;
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case Exception e:
                        if (e.GetType().ToString() == "ApiException")
                        {
                            responseModel.Message += e.Message;
                            responseModel.Message += e.InnerException == null ? "" : "\n" + e.InnerException.Message;
                            responseModel.StatusCode = HttpStatusCode.BadRequest;
                            response.StatusCode = (int)HttpStatusCode.BadRequest;
                        }
                        responseModel.Message = e.Message;
                        responseModel.Message += e.InnerException == null ? "" : "\n" + e.InnerException.Message;

                        responseModel.StatusCode = HttpStatusCode.InternalServerError;
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;

                    default:
                        responseModel.Message = error?.Message;
                        responseModel.StatusCode = HttpStatusCode.InternalServerError;
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                await response.WriteAsJsonAsync(responseModel);
            }
        }

        private bool IsValidContentType(string contentType)
        {
            return contentType.StartsWith("application/json") ||
                   contentType.StartsWith("application/x-www-form-urlencoded") ||
                   contentType.StartsWith("multipart/form-data");
        }

        #endregion Methods
    }
}