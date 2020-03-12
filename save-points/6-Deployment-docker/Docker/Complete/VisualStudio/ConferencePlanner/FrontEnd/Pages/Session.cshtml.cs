using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceDTO;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd
{
    public class SessionModel : PageModel
    {
        public bool IsInPersonalAgenda { get; set; }

        private readonly IApiClient _apiClient;

        public SessionModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public SessionResponse Session { get; set; }

        public int? DayOffset { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Session = await _apiClient.GetSessionAsync(id);

            if (Session == null)
            {
                return RedirectToPage("/Index");
            }

            var allSessions = await _apiClient.GetSessionsAsync();

            var startDate = allSessions.Min(s => s.StartTime?.Date);

            DayOffset = Session.StartTime?.Subtract(startDate ?? DateTimeOffset.MinValue).Days;

            if (User.Identity.IsAuthenticated)
            {
                var sessions = await _apiClient.GetSessionsByAttendeeAsync(User.Identity.Name);

                IsInPersonalAgenda = sessions.Any(s => s.Id == id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int sessionId)
        {
            await _apiClient.AddSessionToAttendeeAsync(User.Identity.Name, sessionId);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveAsync(int sessionId)
        {
            await _apiClient.RemoveSessionFromAttendeeAsync(User.Identity.Name, sessionId);

            return RedirectToPage();
        }
    }
}