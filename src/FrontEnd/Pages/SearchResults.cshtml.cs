using System.Collections.Generic;
using System.Threading.Tasks;
using ConferenceDTO;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages
{
    public class SearchResultsModel : PageModel
    {
        private IApiClient _apiClient;

        public SearchResultsModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public List<SearchResult> SearchResults { get; set; }

        public async Task OnGetAsync(string term)
        {
            SearchResults = await _apiClient.SearchAsync(term);
        }
    }
}