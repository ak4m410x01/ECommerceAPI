using ECommerceAPI.Presentation.Middlewares;

namespace ECommerceAPI.Presentation.Extensions.Middlewares.Exceptions
{
    public static class ServerErrorExceptionApplicationBuilder
    {
        public static IApplicationBuilder UseServerErrorExceptionMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
            return app;
        }
    }
}