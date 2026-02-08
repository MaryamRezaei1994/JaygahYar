using JaygahYar.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JaygahYar.WebAPI.Filters;

public class DuplicateNameExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is not DuplicateNameException ex) return;

        context.Result = new BadRequestObjectResult(new ProblemDetails
        {
            Title = "Duplicate name",
            Detail = ex.Message,
            Status = StatusCodes.Status400BadRequest
        });

        context.ExceptionHandled = true;
    }
}

