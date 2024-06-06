using ECommerceAPI.Application.Behaviors.Validations;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerceAPI.Application.Extensions.Validation
{
    public static class ValidationServiceCollection
    {
        public static IServiceCollection AddValidationConfiguration(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            return services;
        }
    }
}