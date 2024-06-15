using Asp.Versioning;

namespace ECommerceAPI.Presentation.Extensions.ServiceCollections.ApiVersioning
{
    public static class ApiVersioningServiceCollection
    {
        public static IServiceCollection AddApiVersioningConfiguration(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                                     new UrlSegmentApiVersionReader(),
                                 new QueryStringApiVersionReader("api-version"),
                                                   new HeaderApiVersionReader("X-Version"),
                                                   new MediaTypeApiVersionReader("ver"));
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            return services;
        }
    }
}