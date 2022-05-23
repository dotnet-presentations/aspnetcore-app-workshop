using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ConferenceDTO;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages
{
    public class SearchModel : PageModel
    {
        private IApiClient _apiClient;

        public SearchModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public string Term { get; set; }

        public List<SearchResult> SearchResults { get; set; }

        public async Task OnGetAsync(string term)
        {
            Term = term;
            SearchResults = await _apiClient.SearchAsync(term);
        }
    }
}