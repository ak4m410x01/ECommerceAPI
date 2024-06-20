using ECommerceAPI.Presentation.Middlewares;

namespace ECommerceAPI.Presentation.Extensions.Middlewares.Exceptions
{
    public static class ExeptionHandlerApplicationBuilder
    {
        public static IApplicationBuilder UseExeptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            return app;
        }
    }
}