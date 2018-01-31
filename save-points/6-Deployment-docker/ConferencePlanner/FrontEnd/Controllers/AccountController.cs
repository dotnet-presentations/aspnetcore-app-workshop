using System;
using System.Threading.Tasks;
using FrontEnd.Filters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        [SkipWelcome]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect(Url.Page("/Index"));
        }
    }
}