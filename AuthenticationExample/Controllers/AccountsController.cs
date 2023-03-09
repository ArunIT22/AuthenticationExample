using AuthenticationExample.Repositories;
using AuthenticationExample.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthenticationExample.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IRepository _repository;

        public AccountsController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                var userDetails = _repository.ValidateUser(loginVM.UserName, loginVM.Password);

                if (userDetails != null)
                {
                    var claim = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, loginVM.UserName),
                    new Claim(ClaimTypes.Email, userDetails.EmailId),
                    new Claim (ClaimTypes.Role, userDetails.RoleName)
                };

                    var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTime.Now.AddMinutes(10)
                    };

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authProperties);

                    //loginVM.ReturnUrl == null ? "/Home" : loginVM.ReturnUrl;
                    return Redirect(loginVM.ReturnUrl ?? "/Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Credentials");
                }
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
