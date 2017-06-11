using System.Threading.Tasks;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FrontEnd.Pages.Models;

namespace FrontEnd
{
    public class WelcomeModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public WelcomeModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [BindProperty]
        public Attendee Attendee { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var attendee = User.Identity.IsAuthenticated ? await _apiClient.GetAttendeeAsync(HttpContext.User.Identity.Name) : null;

            if (!User.Identity.IsAuthenticated || attendee != null)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _apiClient.AddAttendeeAsync(Attendee);

            return RedirectToPage("/Index");
        }
    }
}