using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using LoanManagement.Exceptions;

namespace LoanManagement.SRP
{
    public class CustomExceptionFilter:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is MyException)
            {
                context.Result = new BadRequestObjectResult(context.Exception.Message);
            }
            else
            {
                context.Result = new BadRequestObjectResult(500);
            }


        }
    }
}
