using ECommerceAPI.Presentation.Extensions.MiddleWares.Authentication;

namespace ECommerceAPI.Presentation.Extensions.MiddleWares
{
    public static class PresentationApplicationBuilder
    {
        public static IApplicationBuilder PresentationMiddleWares(this IApplicationBuilder app)
        {
            #region Config Authentication & Authorization Pipelines

            app.UseAuthenticationMiddleWares();

            #endregion Config Authentication & Authorization Pipelines

            return app;
        }
    }
}