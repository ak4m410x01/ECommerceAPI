namespace ECommerceAPI.Presentation.Extensions.Middlewares.Authorization
{
    public static class AuthorizationApplicationBuilder
    {
        public static IApplicationBuilder UseAuthorizationMiddlewares(this IApplicationBuilder app)
        {
            app.UseAuthorization();
            return app;
        }
    }
}