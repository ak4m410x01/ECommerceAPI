using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerceAPI.Application.Extensions.MediatR
{
    public static class MediatRServiceCollection
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}