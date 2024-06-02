using ECommerceAPI.Application.Interfaces.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using UnitOfWorkImplementation = ECommerceAPI.Persistence.UnitOfWork.UnitOfWork;

namespace ECommerceAPI.Persistence.Extensions.UnitOfWork
{
    public static class UnitOfWorkServiceCollection
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWorkImplementation));
            return services;
        }
    }
}