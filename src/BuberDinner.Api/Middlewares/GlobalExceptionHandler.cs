using System.Net;
using BuberDinner.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Middlewares;

internal sealed class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = exception switch
        {
            UserNotFoundException => CreateProblemDetails(exception, HttpStatusCode.NotFound, httpContext),
            DuplicateEmailException => CreateProblemDetails(exception, HttpStatusCode.Conflict, httpContext),
            InvalidPasswordException => CreateProblemDetails(exception, HttpStatusCode.BadRequest, httpContext),
            ValidationException validationException => CreateValidationProblemDetails(validationException, HttpStatusCode.UnprocessableEntity, httpContext),
            _ => CreateProblemDetails(exception, HttpStatusCode.InternalServerError, httpContext)
        };


        httpContext.Response.StatusCode = problemDetails.Status!.Value;

        if (problemDetails is ValidationProblemDetails validationProblemDetails)
        {
            await httpContext.Response
                .WriteAsJsonAsync(validationProblemDetails, cancellationToken);
        }
        else
        {
            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);
        }

        return true;
    }

    private static ProblemDetails CreateProblemDetails(Exception exception, HttpStatusCode statusCode,
        HttpContext httpContext)
    {
        var type = statusCode switch
        {
            HttpStatusCode.NotFound => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            HttpStatusCode.Conflict => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
            HttpStatusCode.BadRequest => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            _ => "https://tools.ietf.org/html/rfc7231#section-6.6.1"
        };
        
        return new ProblemDetails()
        {
            Status = (int)statusCode,
            Title = exception.Message,
            Type = type,
            Instance = httpContext.Request.Path
        };
    }

    private static ValidationProblemDetails CreateValidationProblemDetails(ValidationException exception,
        HttpStatusCode statusCode, HttpContext httpContext)
    {
        return new ValidationProblemDetails(exception.ErrorsDictionary)
        {
            Status = (int)statusCode,
            Title = exception.Message,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Instance = httpContext.Request.Path
        };
    }
}