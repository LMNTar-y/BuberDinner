using System.Diagnostics;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BuberDinner.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IValidator<TRequest>? validator)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (validator is null)
        {
            return await next();
        }

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors
            .Where(x => x != null)
            .GroupBy(
                x => x.PropertyName,
                x => x.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                })
            .ToDictionary(x => x.Key, x => x.Values);

        throw new Domain.Exceptions.ValidationException(errors);
    }
}

public class LoggingBehavior<TRequest, TResponse>(IValidator<TRequest>? validator, ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        _logger.LogInformation("BuberDinner Request: {@Name} {@Request}", requestName, request);

        TResponse response;
        var stopwatch = Stopwatch.StartNew();

        try
        {
            stopwatch.Start();
            response = await next();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            stopwatch.Stop();
            _logger.LogInformation("BuberDinner Request: {@Name} executed in {@TimeSpan}", requestName, stopwatch.Elapsed);
        }

        return response;
    }
}