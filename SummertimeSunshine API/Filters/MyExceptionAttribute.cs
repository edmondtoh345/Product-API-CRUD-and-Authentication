using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SummertimeSunshine_API.Exceptions;

namespace SummertimeSunshine_API.Filters
{
    public class MyExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var message = context.Exception.Message;
            var exceptionType = context.Exception.GetType();

            if (exceptionType == typeof(ProductAlreadyExistException))
            {
                context.Result = new ConflictObjectResult(message);
            }
            else if (exceptionType == typeof(ProductNotAvailableException))
            {
                context.Result = new NotFoundObjectResult(message);
            }
            else if (exceptionType == typeof(UserAlreadyExistException))
            {
                context.Result = new ConflictObjectResult(message);
            }
            else if (exceptionType == typeof(UserDoesNotExistException))
            {
                context.Result = new NotFoundObjectResult(message);
            }
            else
            {
                context.Result = new BadRequestObjectResult(message);
            }

        }
    }
}
