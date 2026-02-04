using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;
using TechLibrary.Exception.Exceptions;

namespace TechLibrary.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is TechLibraryException ex)
        {
            var response = new ErrorMessagesResponse(ex.ErrorMessages);

            context.Result = new ObjectResult(response)
            {
                StatusCode = (int)ex.StatusCode
            };

            context.ExceptionHandled = true;

        } else
        {
            ThrowUnknownError(context);
        }
    }

    private void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ErrorMessagesResponse(ResourceErrorMessages.UNKNOWN_ERROR);

        context.Result = new ObjectResult(errorResponse)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };

        context.ExceptionHandled = true;
    }
}
