using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LotteriesDigitalApi.Application.Common.Interfaces.Services;

namespace LotteriesDigitalApi.API.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                IServiceExcpetion serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred"),
            };



            return Problem(statusCode: statusCode, title: message);
        }
    }
}
