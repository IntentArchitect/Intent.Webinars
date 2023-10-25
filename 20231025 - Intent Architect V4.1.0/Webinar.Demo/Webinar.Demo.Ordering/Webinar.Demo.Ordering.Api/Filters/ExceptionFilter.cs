using System;
using System.Diagnostics;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Webinar.Demo.Ordering.Application.Common.Exceptions;
using Webinar.Demo.Ordering.Domain.Common.Exceptions;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.AspNetCore.Controllers.ExceptionFilter", Version = "1.0")]

namespace Webinar.Demo.Ordering.Api.Filters
{
    public class ExceptionFilter : Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ValidationException exception:
                    foreach (var error in exception.Errors)
                    {
                        context.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    context.Result = new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState))
                    .AddContextInformation(context);
                    context.ExceptionHandled = true;
                    break;
                case ForbiddenAccessException:
                    context.Result = new ForbidResult();
                    context.ExceptionHandled = true;
                    break;
                case UnauthorizedAccessException:
                    context.Result = new ForbidResult();
                    context.ExceptionHandled = true;
                    break;
                case NotFoundException exception:
                    context.Result = new NotFoundObjectResult(new ProblemDetails
                    {
                        Detail = exception.Message
                    })
                    .AddContextInformation(context);
                    context.ExceptionHandled = true;
                    break;
            }
        }
    }

    internal static class ProblemDetailsExtensions
    {
        public static IActionResult AddContextInformation(this ObjectResult objectResult, ExceptionContext context)
        {
            if (objectResult.Value is not ProblemDetails problemDetails)
            {
                return objectResult;
            }
            problemDetails.Extensions.Add("traceId", Activity.Current?.Id ?? context.HttpContext.TraceIdentifier);
            problemDetails.Type = "https://httpstatuses.io/" + (objectResult.StatusCode ?? problemDetails.Status);
            return objectResult;
        }
    }
}