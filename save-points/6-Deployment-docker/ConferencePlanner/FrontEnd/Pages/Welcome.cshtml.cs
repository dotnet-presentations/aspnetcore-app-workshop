using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FrontEnd.Filters;
using FrontEnd.Pages.Models;

namespace FrontEnd.Pages
{
    [SkipWelcome]
    public class WelcomeModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public WelcomeModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [BindProperty]
        public Attendee Attendee { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            await _apiClient.AddAttendeeAsync(Attendee);

            return RedirectToPage("/Index");
        }
    }
}