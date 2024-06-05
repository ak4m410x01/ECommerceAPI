using ECommerceAPI.Shared.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace ECommerceAPI.Presentation.MiddleWares
{
    public class GlobalExceptionHandlerMiddleWare
    {
        #region Properties

        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IHostEnvironment _environment;

        #endregion Properties

        #region Constructors

        public GlobalExceptionHandlerMiddleWare(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger, IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        #endregion Constructors

        #region Methods

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = new ServerErrorException();

                if (_environment.IsDevelopment())
                {
                    response.Details = ex.ToString() ?? "";
                }

                await context.Response.WriteAsJsonAsync(response);
            }
        }

        #endregion Methods
    }
}