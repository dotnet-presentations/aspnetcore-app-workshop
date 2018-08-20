using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ConferenceDTO;
using System.Text.Encodings.Web;

namespace FrontEnd.Pages
{
    public class SessionModel : PageModel
    {
        private readonly IApiClient _apiClient;

        private readonly HtmlEncoder _htmlEncoder;
    

        public SessionModel(IApiClient apiClient, HtmlEncoder htmlEncoder)
        {
            _apiClient = apiClient;
            _htmlEncoder = htmlEncoder;
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
            if (!string.IsNullOrEmpty(Session.Abstract))
            {
                var encodedCrLf = _htmlEncoder.Encode("\r\n");
                var encodedAbstract = _htmlEncoder.Encode(Session.Abstract);
                Session.Abstract = "<p>" + String.Join("</p><p>", encodedAbstract.Split(encodedCrLf, StringSplitOptions.RemoveEmptyEntries)) + "</p>";
            }

            return Page();
        }
    }
}
