using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;

namespace FrontEnd.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAuthenticationSchemeProvider _authSchemeProvider;

        public LoginModel(IAuthenticationSchemeProvider authSchemeProvider)
        {
            _authSchemeProvider = authSchemeProvider;
        }

        public IEnumerable<AuthenticationScheme> AuthSchemes { get; set; }

        public async Task<IActionResult> OnGet()
        {
            AuthSchemes = await _authSchemeProvider.GetRequestHandlerSchemesAsync();

            return Page();
        }

        public IActionResult OnPost(string scheme)
        {
            return Challenge(new AuthenticationProperties { RedirectUri = Url.Page("/Index") }, scheme);
        }
    }
}