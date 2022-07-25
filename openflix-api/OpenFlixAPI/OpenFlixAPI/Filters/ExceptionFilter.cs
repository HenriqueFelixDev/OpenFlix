using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OpenFlixAPI.Domain.Exceptions;

namespace OpenFlixAPI.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is BaseException)
            {
                BaseException exception = (BaseException) context.Exception;

                var error = new
                {
                    Code = exception.Code,
                    Message = exception.Message
                };

                context.Result = new ObjectResult(error)
                {
                    StatusCode = exception.Code
                };

                return;
            }

            Console.WriteLine($"Exception: {context.Exception.Message}");

            context.Result = new ObjectResult("Um erro inesperado ocorreu")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
