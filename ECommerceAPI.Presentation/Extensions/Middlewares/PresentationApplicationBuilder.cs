using ECommerceAPI.Presentation.Extensions.MiddleWares.Authentication;
using ECommerceAPI.Presentation.Extensions.MiddleWares.Exceptions;
using ECommerceAPI.Presentation.Extensions.MiddleWares.Swagger;

namespace ECommerceAPI.Presentation.Extensions.MiddleWares
{
    public static class PresentationApplicationBuilder
    {
        public static IApplicationBuilder UsePresentationMiddleWares(this IApplicationBuilder app, IHostEnvironment environment)
        {
            #region Config Authentication & Authorization Pipelines

            app.UseServerErrorExceptionMiddleWares();

            app.UseSwaggerMiddleWares(environment);

            app.UseAuthenticationMiddleWares();

            #endregion Config Authentication & Authorization Pipelines

            return app;
        }
    }
}