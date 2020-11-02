using Example.Api.Web.Response;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace Example.Api.Web.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        private readonly ILogger<ErrorsController> Logger;

        public ErrorsController(ILogger<ErrorsController> logger)
        {
            this.Logger = logger;
        }

        [Route("error-local-development")]
        public ApiErrorResponse ErrorLocalDevelopment()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;
            HttpStatusCode code = HttpStatusCode.InternalServerError; // Code 500 par défaut 

            this.Logger.LogError(exception.Message);

            return new ApiErrorResponse(code, exception);
        }

        [Route("error")]
        public ApiErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error; // Your exception
            HttpStatusCode code = HttpStatusCode.InternalServerError;

            //if (exception is NotFoundException) code = 404; // Not Found
            //else if (exception is MyUnauthException) code = 401; // Unauthorized
            //else if (exception is MyException) code = 400; // Bad Request

            Response.StatusCode = (int)code;

            return new ApiErrorResponse(HttpStatusCode.InternalServerError, exception);
        }
    }
}
