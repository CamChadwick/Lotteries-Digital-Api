using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ErrorOr;
using LotteriesDigitalApi.API.Common.Http;

namespace LotteriesDigitalApi.API.Controllers
{
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {

            if (errors.Count is 0)
            {
                return Problem();
            }

            if (errors.All(error => error.Type == ErrorType.Validation))
            {
                return ValidationProblem(errors);
            }

            HttpContext.Items[HttpContextItemKeys.Errors] = errors;

            return Problem(errors[0]);
        }

        private IActionResult Problem(Error error)
        {
            var StatusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: StatusCode, title: error.Description);
        }

        private IActionResult ValidationProblem(List<Error> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(error.Code, error.Description);
            }
            return ValidationProblem();
        }
    }
}