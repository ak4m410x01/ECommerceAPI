using ECommerceAPI.Presentation.Extensions.MiddleWares.Authentication;
using ECommerceAPI.Presentation.Extensions.MiddleWares.Exceptions;
using ECommerceAPI.Presentation.Extensions.MiddleWares.Swagger;

namespace ECommerceAPI.Presentation.Extensions.MiddleWares
{
    public static class PresentationApplicationBuilder
    {
        public static IApplicationBuilder UsePresentationMiddleWares(this IApplicationBuilder app, IHostEnvironment environment)
        {
            app.UseServerErrorExceptionMiddleWares();

            app.UseSwaggerMiddleWares(environment);

            app.UseStatusCodePagesWithReExecute("/Api/Errors/{0}");

            app.UseAuthenticationMiddleWares();

            app.UseErrorHandlerMiddleWare();

            return app;
        }
    }
}