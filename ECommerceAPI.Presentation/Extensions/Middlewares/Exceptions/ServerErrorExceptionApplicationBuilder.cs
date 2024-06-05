using ECommerceAPI.Presentation.MiddleWares;
using ECommerceAPI.Shared.Exceptions;

namespace ECommerceAPI.Presentation.Extensions.MiddleWares.Exceptions
{
    public static class ServerErrorExceptionApplicationBuilder
    {
        public static IApplicationBuilder UseServerErrorExceptionMiddleWares(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionHandlerMiddleWare>();
            return app;
        }
    }
}