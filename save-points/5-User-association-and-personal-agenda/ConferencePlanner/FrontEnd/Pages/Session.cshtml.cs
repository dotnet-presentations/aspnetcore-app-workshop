using ConferenceDTO;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages;
public class SessionModel : PageModel
{
    private readonly IApiClient _apiClient;
    public SessionResponse? Session { get; set; }
    public int? DayOffset { get; set; }
    public bool IsInPersonalAgenda { get; set; }


    public SessionModel(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Session = await _apiClient.GetSessionAsync(id);

        if (Session == null)
        {
            return RedirectToPage("/Index");
        }

        if (User.Identity.IsAuthenticated)
        {
            var sessions = await _apiClient.GetSessionsByAttendeeAsync(User.Identity.Name);

            IsInPersonalAgenda = sessions.Any(s => s.Id == id);
        }

        var allSessions = await _apiClient.GetSessionsAsync();
        var startDate = allSessions.Min(s => s.StartTime?.Date);
        DayOffset = Session.StartTime?.Subtract(startDate ?? DateTimeOffset.MinValue).Days;

        return Page();
    }
}