namespace ECommerceAPI.Presentation.Extensions.Middlewares.Swagger
{
    public static class SwaggerApplicationBuilder
    {
        public static IApplicationBuilder UseSwaggerMiddlewares(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
