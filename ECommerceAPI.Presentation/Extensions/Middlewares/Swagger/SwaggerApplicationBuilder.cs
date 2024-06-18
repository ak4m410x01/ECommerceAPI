namespace ECommerceAPI.Presentation.Extensions.Middlewares.Swagger
{
    public static class SwaggerApplicationBuilder
    {
        public static IApplicationBuilder UseSwaggerMiddlewares(this IApplicationBuilder app, IHostEnvironment environment)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("v1/swagger.json", "v1");
            });
            return app;
        }
    }
}