using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceDTO;
using DTO;

namespace FrontEnd.Services
{
    public interface IApiClient
    {
        Task<List<SessionResponse>> GetSessionsAsync();
        Task<SessionResponse> GetSessionAsync(int id);
        Task<List<SpeakerResponse>> GetSpeakersAsync();
        Task<SpeakerResponse> GetSpeakerAsync(int id);
        Task PutSessionAsync(Session session);
        Task<List<SearchResult>> SearchAsync(string query);
        Task AddAttendeeAsync(Attendee attendee);
        Task<AttendeeResponse> GetAttendeeAsync(string name);
        Task DeleteSessionAsync(int id);
        Task<List<SessionResponse>> GetSessionsByAttendeeAsync(string name);
        Task AddSessionToAttendeeAsync(string name, int sessionId);
        Task RemoveSessionFromAttendeeAsync(string name, int sessionId);
    }
}