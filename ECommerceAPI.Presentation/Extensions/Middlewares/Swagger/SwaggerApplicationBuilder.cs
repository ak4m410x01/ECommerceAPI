namespace ECommerceAPI.Presentation.Extensions.MiddleWares.Swagger
{
    public static class SwaggerApplicationBuilder
    {
        public static IApplicationBuilder UseSwaggerMiddleWares(this IApplicationBuilder app, IHostEnvironment environment)
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