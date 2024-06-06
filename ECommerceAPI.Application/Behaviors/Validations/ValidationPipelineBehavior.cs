using FluentValidation;
using MediatR;

namespace ECommerceAPI.Application.Behaviors.Validations
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        #region Properties

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        #endregion Properties

        #region Constructors

        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        #endregion Constructors

        #region Methods

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var results = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = results.SelectMany(r => r.Errors).Where(f => f is not null).ToList();

                if (failures.Count != 0)
                {
                    var message = failures.Select(x => $"{x.PropertyName}: {x.ErrorMessage}").FirstOrDefault();
                    throw new ValidationException(message);
                }
            }
            return await next();
        }

        #endregion Methods
    }
}