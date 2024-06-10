using ECommerceAPI.Presentation.Extensions.Middlewares.Authentication;
using ECommerceAPI.Presentation.Extensions.Middlewares.Cors;
using ECommerceAPI.Presentation.Extensions.Middlewares.Exceptions;
using ECommerceAPI.Presentation.Extensions.Middlewares.Swagger;

namespace ECommerceAPI.Presentation.Extensions.Middlewares
{
    public static class PresentationApplicationBuilder
    {
        public static IApplicationBuilder UsePresentationMiddlewares(this IApplicationBuilder app, IHostEnvironment environment)
        {
            app.UseServerErrorExceptionMiddlewares();

            app.UseSwaggerMiddlewares(environment);

            app.UseCorsMiddlewares();

            app.UseStatusCodePagesWithReExecute("/Api/Errors/{0}");

            app.UseAuthenticationMiddlewares();

            app.UseErrorHandlerMiddleware();

            return app;
        }
    }
}