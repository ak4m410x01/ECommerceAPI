using ECommerceAPI.Application.Interfaces.Repositories.Base;
using ECommerceAPI.Persistence.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence.Extensions.Repositories.Base
{
    public static class BaseRepositoryServiceCollection
    {
        public static IServiceCollection AddBaseRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}