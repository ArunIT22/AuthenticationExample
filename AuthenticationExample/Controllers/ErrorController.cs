using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationExample.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = " Sorry, the resource your requested could not be found!";
                    break;
                case 400:
                    ViewBag.ErrorMessage = "Invalid Request. Please check the URL.";
                    break;
            }
            return View();
        }

        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.Path = exceptionDetails.Path;
            ViewBag.ErrorMessage = exceptionDetails.Error.Message;
           // ViewBag.StackTrace = exceptionDetails.Error.StackTrace;

            return View("UnhandledError");
        }
    }
}
