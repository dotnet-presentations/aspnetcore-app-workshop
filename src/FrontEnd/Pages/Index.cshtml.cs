using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceDTO;
using FrontEnd.Infrastructure;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        protected readonly IApiClient _apiClient;
        private readonly IMemoryCache _cache;

        public IndexModel(IApiClient apiClient, IMemoryCache cache)
        {
            _apiClient = apiClient;
            _cache = cache;
        }

        public ConferenceData ConferenceModel { get; private set; }

        public List<int> UserSessions { get; set; }

        public int CurrentDayOffset { get; set; }

        [TempData]
        public string Message { get; set; }

        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        public async Task OnGetAsync(int day = 0)
        {
            CurrentDayOffset = day;

            if (User.Identity.IsAuthenticated)
            {
                var userSessions = await _apiClient.GetSessionsByAttendeeAsync(User.Identity.Name);

                UserSessions = userSessions.Select(u => u.Id).ToList();
            }

            ConferenceModel = await GetConferenceDataAsync();
        }
        
        public async Task<IActionResult> OnPostAsync(int sessionId, int day = 0)
        {
            await _apiClient.AddSessionToAttendeeAsync(User.Identity.Name, sessionId);

            return RedirectToPage(new { day });
        }

        public async Task<IActionResult> OnPostRemoveAsync(int sessionId, int day = 0)
        {
            await _apiClient.RemoveSessionFromAttendeeAsync(User.Identity.Name, sessionId);

            return RedirectToPage(new { day });
        }

        public virtual bool ShowSessionsNotInAgenda() => true;

        protected Task<ConferenceData> GetConferenceDataAsync()
        {
            return _cache.GetOrCreateAsync(CacheKeys.ConferenceData, async entry =>
            {
                var sessions = await _apiClient.GetSessionsAsync();

                var startDate = sessions.Min(s => s.StartTime?.Date);
                var endDate = sessions.Max(s => s.EndTime?.Date);

                var numberOfDays = ((endDate - startDate)?.Days + 1) ?? 0;

                var confData = new ConferenceData(numberOfDays);

                for (int i = 0; i < numberOfDays; i++)
                {
                    var filterDate = startDate?.AddDays(i);

                    confData[i] = sessions.Where(s => s.StartTime?.Date == filterDate)
                                          .OrderBy(s => s.TrackId)
                                          .GroupBy(s => s.StartTime)
                                          .OrderBy(g => g.Key);
                }

                entry.SetSlidingExpiration(TimeSpan.FromHours(1));

                confData.StartDate = startDate;
                confData.EndDate = endDate;
                confData.DayOffsets = Enumerable.Range(0, numberOfDays)
                                                .Select(offset =>
                                                    (offset, (startDate?.AddDays(offset))?.DayOfWeek));

                return confData;
            });
        }

        public class ConferenceData : Dictionary<int, IEnumerable<IGrouping<DateTimeOffset?, SessionResponse>>>
        {
            public ConferenceData(int capacity) : base(capacity)
            {
            }

            public DateTimeOffset? StartDate { get; set; }

            public DateTimeOffset? EndDate { get; set; }

            public IEnumerable<(int Offset, DayOfWeek? DayofWeek)> DayOffsets { get; set; }
        }
    }
}
