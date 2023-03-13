using AuthenticationExample.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AuthenticationExample.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _logger.Log(LogLevel.Information, "This is my Home Controller");
            _logger.Log(LogLevel.Warning, "This is warning Message");
            _logger.LogInformation("Message from Log INformation method");
            _logger.LogDebug("Log Debug Message");
            _logger.Log(LogLevel.Trace, "Message from Trace");
            
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            _logger.LogInformation("Default Value = {count}", 10);
            _logger.LogInformation("Date and Time :{date}", DateTime.Now.ToString());
            string name = "Hari";
            string city = "Chennai";

            _logger.LogInformation("Name :{name}, City :{city}", name, city);

            try
            {
                throw new Exception("Error Occurred, When connecting to DB");
            }
            catch (Exception e)
            {
                _logger.LogError(1234, e, "Error occurred on Index Method");
            }
            return View();
        }

        //[Authorize(Roles = "admin")]
        public IActionResult Privacy()
        {
            try
            {
                throw new Exception("Unable to create object");
            }
            catch (Exception e)
            {
                _logger.LogError(1234, e, "Error occurred on Privacy Method");
            }
            return View();
        }

        [Authorize(Roles = "admin, employee")]
        public IActionResult AdminEmployee()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}