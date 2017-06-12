using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceDTO;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages
{
    public class SessionModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public SessionModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public SessionResponse Session { get; set; }

        public bool IsFavorite { get; set; }

        public int? DayOffset { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Session = await _apiClient.GetSessionAsync(id);

            if (Session == null)
            {
                return RedirectToPage("/Index");
            }

            var attendee = await _apiClient.GetAttendeeAsync(User.Identity.Name);

            IsFavorite = attendee?.Sessions.Any(s => s.ID == id) ?? false;

            var allSessions = await _apiClient.GetSessionsAsync();

            var startDate = allSessions.Min(s => s.StartTime?.Date);

            DayOffset = Session.StartTime?.DateTime.Subtract(startDate ?? DateTime.MinValue).Days;

            if (!string.IsNullOrEmpty(Session.Abstract))
            {
                Session.Abstract = "<p>" + String.Join("</p><p>", Session.Abstract.Split("\r\n", StringSplitOptions.RemoveEmptyEntries)) + "</p>";
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
