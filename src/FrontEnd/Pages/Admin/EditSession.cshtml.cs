using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using FrontEnd.Infrastructure;
using FrontEnd.Pages.Models;
using FrontEnd.Services;

namespace FrontEnd.Pages
{
    public class EditSessionModel : PageModel
    {
        private readonly IApiClient _apiClient;
        private readonly IMemoryCache _cache;

        public EditSessionModel(IApiClient apiClient, IMemoryCache cache)
        {
            _apiClient = apiClient;
            _cache = cache;
        }

        [BindProperty]
        public Session Session { get; set; }

        [TempData]
        public string Message { get; set; }

        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        public async Task<IActionResult> OnGet(int id)
        {
            var session = await _apiClient.GetSessionAsync(id);

            if (session == null)
            {
                return RedirectToPage("/Index");
            }

            Session = new Session
            {
                Id = session.Id,
                TrackId = session.TrackId,
                Title = session.Title,
                Abstract = session.Abstract,
                StartTime = session.StartTime,
                EndTime = session.EndTime
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apiClient.PutSessionAsync(Session);

            _cache.Remove(CacheKeys.ConferenceData);

            Message = "Session updated successfully!";

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var session = await _apiClient.GetSessionAsync(id);

            if (session != null)
            {
                await _apiClient.DeleteSessionAsync(id);
            }

            _cache.Remove(CacheKeys.ConferenceData);

            Message = "Session deleted successfully!";

            return RedirectToPage("/Index");
        }
    }
}