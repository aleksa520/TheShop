using FluentValidation;
using MediatR;

namespace Shop.Application.PipelineBehaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if(_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResult = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failuers = validationResult.SelectMany(r => r.Errors).Where(f => f is not null).ToList();

            if(failuers.Any())
            {
                throw new ValidationException(failuers);
            }
        }

        return await next();
    }
}
