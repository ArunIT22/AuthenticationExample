using Microsoft.AspNetCore.Mvc;

namespace AuthenticationExample.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception("An Error Occurred");
            //return View();
        }
    }
}
