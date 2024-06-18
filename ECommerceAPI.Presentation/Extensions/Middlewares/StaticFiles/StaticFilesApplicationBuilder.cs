namespace ECommerceAPI.Presentation.Extensions.Middlewares.StaticFiles
{
    public static class StaticFilesApplicationBuilder
    {
        public static IApplicationBuilder UseStaticFilesMiddleware(this IApplicationBuilder app)
        {
            app.UseStaticFiles();
            return app;
        }
    }
}