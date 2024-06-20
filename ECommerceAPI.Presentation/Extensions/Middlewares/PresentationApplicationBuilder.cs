using ECommerceAPI.Presentation.Extensions.Middlewares.Authentication;
using ECommerceAPI.Presentation.Extensions.Middlewares.Authorization;
using ECommerceAPI.Presentation.Extensions.Middlewares.Cors;
using ECommerceAPI.Presentation.Extensions.Middlewares.Exceptions;
using ECommerceAPI.Presentation.Extensions.Middlewares.StaticFiles;
using ECommerceAPI.Presentation.Extensions.Middlewares.Swagger;

namespace ECommerceAPI.Presentation.Extensions.Middlewares
{
    public static class PresentationApplicationBuilder
    {
        public static IApplicationBuilder UsePresentationMiddlewares(this IApplicationBuilder app, IHostEnvironment environment)
        {
            app.UseGlobalExceptionMiddlewares();

            app.UseExeptionHandlerMiddleware();

            app.UseStatusCodePagesWithReExecute("/Api/V1/Errors/{0}");

            app.UseCorsMiddlewares();

            app.UseSwaggerMiddlewares(environment);

            app.UseStaticFilesMiddleware();

            app.UseAuthenticationMiddlewares();

            app.UseAuthorizationMiddlewares();

            return app;
        }
    }
}