using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using FrontEnd.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FrontEnd.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        // -1 = uninitialized, 0 = not allowed, 1 = allowed
        private static long _allowAdminCreation = -1;
        private static long _adminCreationKey = 0;

        private readonly IdentityDbContext _dbContext;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            IdentityDbContext dbContext,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public bool AllowAdminCreation { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Admin creation key")]
            public long? AdminCreationKey { get; set; }
        }

        public async Task OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            // Determine if there is an admin already, and if not, generate a single-use admin creation key
            if (Interlocked.Read(ref _allowAdminCreation) == -1)
            {
                if (await _dbContext.Users.AnyAsync(user => user.IsAdmin))
                {
                    // There are already admin users so disable admin creation
                    Interlocked.Exchange(ref _allowAdminCreation, 0);
                }
                else
                {
                    // There are no admin users so enable admin creation
                    Interlocked.Exchange(ref _allowAdminCreation, 1);

                    var adminKey = BitConverter.ToInt64(Guid.NewGuid().ToByteArray(), 7);
                    Interlocked.CompareExchange(ref _adminCreationKey, adminKey, 0);
                }
            }

            if (Interlocked.Read(ref _allowAdminCreation) == 1)
            {
                AllowAdminCreation = true;

                _logger.LogInformation("Admin creation is enabled. Use the following key to create an admin user: {adminKey}", _adminCreationKey);
            }
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new User { UserName = Input.Email, Email = Input.Email };

                if (_adminCreationKey != 0 && Interlocked.Read(ref _allowAdminCreation) == 1 && Input.AdminCreationKey == _adminCreationKey)
                {
                    // Set as admin user
                    user.IsAdmin = true;
                }

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    if (user.IsAdmin)
                    {
                        _logger.LogInformation("Admin user created a new account with password.");

                        // Disable admin creation
                        Interlocked.Exchange(ref _allowAdminCreation, 0);
                    }
                    else
                    {
                        _logger.LogInformation("User created a new account with password.");
                    }

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
