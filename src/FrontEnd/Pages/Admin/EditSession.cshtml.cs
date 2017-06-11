using System.Threading.Tasks;
using ConferenceDTO;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages
{
    public class EditSessionModel : PageModel
    {
        private readonly IApiClient _apiClient;
        public EditSessionModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [BindProperty]
        public Session Session { get; set; }

        public async Task OnGet(int id)
        {
            Session = await _apiClient.GetSessionAsync(id);
        }

        public async Task OnPostAsync()
        {
            // TODO: Validation errors etc
            await _apiClient.PutSessionAsync(Session);
        }
    }
}