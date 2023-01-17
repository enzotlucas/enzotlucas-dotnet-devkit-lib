using enzotlucas.DevKit.Core.Exceptions;
using enzotlucas.DevKit.Core.UseCases;
using FluentValidation;
using MediatR;

namespace enzotlucas.DevKit.Core.Validators
{
    public sealed class UseCasesValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IUseCase<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public UseCasesValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validationErrors = _validators.Select(validation => validation.Validate(context))
                                              .Where(validation => validation is not null && !validation.IsValid)
                                              .SelectMany(validationResult => validationResult.ToDictionary())
                                              .ToDictionary(vr => vr.Key, vr => vr.Value);

            if (validationErrors.Any())
            {
                throw new BusinessException(validationErrors, "Invalid request", request.CorrelationId);
            }

            return next();
        }
    }
}
