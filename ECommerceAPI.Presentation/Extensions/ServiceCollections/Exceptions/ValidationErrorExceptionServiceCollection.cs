using ECommerceAPI.Shared.Exceptions.ValidationError;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Extensions.ServiceCollections.Exceptions
{
    public static class ValidationErrorExceptionServiceCollection
    {
        public static IServiceCollection AddValidationErrorExceptionConfiguration(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
                        options.InvalidModelStateResponseFactory = (context) =>
                        {
                            var errors = context.ModelState
                                                .Where(pair => pair.Value?.Errors.Count() > 0)
                                                .SelectMany(pair => pair.Value!.Errors)
                                                .Select(error => error.ErrorMessage)
                                                .ToList();

                            var validationError = new ValidationErrorExceptionResponse()
                            {
                                Errors = errors
                            };

                            return new BadRequestObjectResult(validationError);
                        });
            return services;
        }
    }
}