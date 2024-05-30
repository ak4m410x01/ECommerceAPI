namespace ECommerceAPI.Presentation.Extensions.Middlewares.Authentication
{
    public static class AuthenticationApplicationBuilder
    {
        public static IApplicationBuilder UseAuthenticationMiddlewares(this IApplicationBuilder app)
        {
            app.UseAuthorization();
            app.UseAuthorization();
            return app;
        }
    }
}
