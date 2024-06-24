using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Persistence.Specifications.Base;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence.Extensions.Specifications
{
    public static class SpecificationServiceCollection
    {
        public static IServiceCollection AddSpecificationConfiguration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseSpecification<>), typeof(BaseSpecification<>));
            return services;
        }
    }
}