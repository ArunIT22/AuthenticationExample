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
    }
}
