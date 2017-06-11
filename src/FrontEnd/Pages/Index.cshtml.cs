using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceDTO;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public IndexModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IEnumerable<IGrouping<DayOfWeek?, IGrouping<DateTimeOffset?, SessionResponse>>> Sessions { get; set; }

        public async Task OnGet(int day = 0)
        {
            var sessions = await _apiClient.GetSessionsAsync();

            var firstDay = sessions.Min(s => s.StartTime?.Day);
            var filterDay = firstDay + day;

            Sessions = sessions.Where(s => s.StartTime?.Date.Day == filterDay)
                               .OrderBy(s => s.TrackId)
                               .GroupBy(s => s.StartTime)
                               .OrderBy(g => g.Key)
                               .GroupBy(g => g.Key?.DayOfWeek);
        }
    }
}
