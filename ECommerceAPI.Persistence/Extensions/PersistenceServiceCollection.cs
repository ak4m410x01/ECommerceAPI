using ECommerceAPI.Application.Extensions.MediatR;
using ECommerceAPI.Persistence.Extensions.DbContexts;
using ECommerceAPI.Persistence.Extensions.Identity;
using ECommerceAPI.Persistence.Extensions.Repositories.Base;
using ECommerceAPI.Persistence.Extensions.Specifications;
using ECommerceAPI.Persistence.Extensions.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence.Extensions
{
    public static class PersistenceServiceCollection
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContexts(configuration)
                    .AddIdentity();

            services.AddBaseRepository()
                    .AddUnitOfWork();

            services.AddSpecification();

            //services.AddMediatR();

            return services;
        }
    }
}