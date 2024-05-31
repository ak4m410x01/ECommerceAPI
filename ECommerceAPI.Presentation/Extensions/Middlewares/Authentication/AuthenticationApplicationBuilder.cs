namespace ECommerceAPI.Presentation.Extensions.MiddleWares.Authentication
{
    public static class AuthenticationApplicationBuilder
    {
        public static IApplicationBuilder UseAuthenticationMiddleWares(this IApplicationBuilder app)
        {
            app.UseAuthorization();
            app.UseAuthorization();
            return app;
        }
    }
}