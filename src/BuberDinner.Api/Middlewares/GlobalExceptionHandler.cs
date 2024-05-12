using System.Net;
using BuberDinner.Domain.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace BuberDinner.Api.Middlewares;

internal sealed class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var statusCode = GetStatusCode(exception);
        var type = GetDescriptionLink(statusCode);

        var problemDetails = new
        {
            Status = (int)statusCode,
            Title = exception.Message,
            Type = type,
            Instance = httpContext.Request.Path,
            Errors = GetErrors(exception),
        };
        httpContext.Response.StatusCode = problemDetails.Status;

        await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private static string GetDescriptionLink(HttpStatusCode statusCode) => statusCode switch
    {
        HttpStatusCode.NotFound => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
        HttpStatusCode.Conflict => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
        HttpStatusCode.BadRequest or
        HttpStatusCode.UnprocessableEntity => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
        _ => "https://tools.ietf.org/html/rfc7231#section-6.6.1"
    };

    private static HttpStatusCode GetStatusCode(Exception exception) => exception switch
    {
        UserNotFoundException => HttpStatusCode.NotFound,
        DuplicateEmailException => HttpStatusCode.Conflict,
        InvalidPasswordException => HttpStatusCode.BadRequest,
        ValidationException => HttpStatusCode.UnprocessableEntity,
        _ => HttpStatusCode.InternalServerError
    };

    private static IDictionary<string, string[]> GetErrors(Exception exception)
    {
        IDictionary<string, string[]> errors = new Dictionary<string, string[]>();
        if (exception is ValidationException validationException)
        {
            errors = validationException.ErrorsDictionary;
        }
        else
        {
            errors.Add("Exception", [exception.Message]);
        }

        return errors;
    }
}