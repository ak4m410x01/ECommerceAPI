using ECommerceAPI.Presentation.MiddleWares;

namespace ECommerceAPI.Presentation.Extensions.MiddleWares.Exceptions
{
    public static class ErrorHandlerApplicationBuilder
    {
        public static IApplicationBuilder UseErrorHandlerMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleWare>();
            return app;
        }
    }
}