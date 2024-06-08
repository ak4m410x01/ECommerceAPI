namespace ECommerceAPI.Presentation.Extensions.Middlewares.Swagger
{
    public static class SwaggerApplicationBuilder
    {
        public static IApplicationBuilder UseSwaggerMiddlewares(this IApplicationBuilder app, IHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            return app;
        }
    }
}