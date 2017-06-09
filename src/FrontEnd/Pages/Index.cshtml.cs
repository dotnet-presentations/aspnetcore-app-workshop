using System.Collections.Generic;
using System.Threading.Tasks;
using ConferenceDTO;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public IndexModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IList<SessionResponse> Sessions { get; set; }

        public async Task OnGet()
        {
            Sessions = await _apiClient.GetSessionsAsync();
        }
    }
}
