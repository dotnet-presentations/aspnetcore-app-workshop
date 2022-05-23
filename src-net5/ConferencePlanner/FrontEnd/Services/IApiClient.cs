using System.Collections.Generic;
using System.Threading.Tasks;
using ConferenceDTO;

namespace FrontEnd.Services
{
    public interface IApiClient
    {
        Task<List<SessionResponse>> GetSessionsByAttendeeAsync(string name);
        Task<List<SessionResponse>> GetSessionsAsync();
        Task<SessionResponse> GetSessionAsync(int id);
        Task<List<SpeakerResponse>> GetSpeakersAsync();
        Task<SpeakerResponse> GetSpeakerAsync(int id);
        Task PutSessionAsync(Session session);
        Task<List<SearchResult>> SearchAsync(string query);
        Task<bool> AddAttendeeAsync(Attendee attendee);
        Task<AttendeeResponse> GetAttendeeAsync(string name);
        Task DeleteSessionAsync(int id);
        Task AddSessionToAttendeeAsync(string name, int sessionId);
        Task RemoveSessionFromAttendeeAsync(string name, int sessionId);
        Task<bool> CheckHealthAsync();
    }
}
