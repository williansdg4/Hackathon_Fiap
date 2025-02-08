using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.Auxiliar;

namespace TimeScheduleRegister.Api.Auxiliar
{
    public class ExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is StatusCodeException excetion)
            {
                var result = new ObjectResult(new { excetion.Message })
                {
                    StatusCode = (int)excetion.StatusCode
                };

                context.Result = result;
                return;
            }

            base.OnException(context);
        }
    }
}
