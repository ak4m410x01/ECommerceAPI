namespace ECommerceAPI.Presentation.Extensions.ServiceCollections.Cors
{
    public static class CorsServiceCollection
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("_AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });
            return services;
        }
    }
}