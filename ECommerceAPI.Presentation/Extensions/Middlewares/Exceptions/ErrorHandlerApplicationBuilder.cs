using ECommerceAPI.Presentation.Middlewares;

namespace ECommerceAPI.Presentation.Extensions.Middlewares.Exceptions
{
    public static class ErrorHandlerApplicationBuilder
    {
        public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
            return app;
        }
    }
}