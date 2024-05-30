using ECommerceAPI.Presentation.Extensions.Middlewares.Authentication;

namespace ECommerceAPI.Presentation.Extensions.Middlewares
{
    public static class PresentationApplicationBuilder
    {
        public static IApplicationBuilder PresentationMiddlewares(this IApplicationBuilder app)
        {
            #region Config Authentication & Authorization Pipelines
            app.UseAuthenticationMiddlewares();
            #endregion

            return app;
        }
    }
}
