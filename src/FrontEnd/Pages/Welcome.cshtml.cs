using System.Threading.Tasks;
using ConferenceDTO;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            // If the user is already associated then redirect
            var attendee = await _apiClient.GetAttendeeAsync(User.Identity.Name);

            if (attendee != null)
            {
                return RedirectToPage("/");
            }

            // Otherwise, link the user
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _apiClient.AddAttendeeAsync(Attendee);

            return RedirectToPage("/");
        }
    }
}