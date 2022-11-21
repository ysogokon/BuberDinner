using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
  [ApiController]
  public class ErrorsController : ControllerBase
  {
    [Route("/error")]
    public IActionResult Error()
    {
      Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

      // tuple
      var (statusCode, message) = exception switch
      {
        IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
        _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured.")
      };

      return Problem(statusCode: statusCode, detail: message);
    }
  }
}