using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        ProblemDetails problemDetails; 

        switch (exception)
        {
            case ArgumentException:
            case InvalidOperationException:
                {
                problemDetails = new ProblemDetails()
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Title = exception.Message,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    Instance = context.HttpContext.Request.Path
                };
                break;
            }
            default:
            {
                problemDetails = new ProblemDetails()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Title = exception.Message,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                    Instance = context.HttpContext.Request.Path
                };
                break;
            }
        }

        context.Result = new ObjectResult(problemDetails);

        context.ExceptionHandled = true;
    }
}