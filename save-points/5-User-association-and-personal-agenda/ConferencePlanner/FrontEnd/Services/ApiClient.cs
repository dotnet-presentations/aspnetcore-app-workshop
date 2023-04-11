using System.Net;
using System.Text.Json;
using ConferenceDTO;

namespace FrontEnd.Services;

public class ApiClient : IApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> AddAttendeeAsync(Attendee attendee)
    {
        var response = await _httpClient.PostAsJsonAsync($"/api/Attendee", attendee);
        if (response.StatusCode == HttpStatusCode.Conflict)
        {
            return false;
        }
        response.EnsureSuccessStatusCode();
        return true;
    }

    public async Task<AttendeeResponse?> GetAttendeeAsync(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return null;
        }
        var response = await _httpClient.GetAsync($"/api/Attendee/{name}");
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<AttendeeResponse>();
    }

    public async Task<SessionResponse?> GetSessionAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/api/Session/{id}");
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<SessionResponse>();
    }

    public async Task<List<SessionResponse>> GetSessionsAsync()
    {
        var response = await _httpClient.GetAsync("/api/Session");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<SessionResponse>>() ?? new();
    }

    public async Task DeleteSessionAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"/api/Session/{id}");
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return;
        }
        response.EnsureSuccessStatusCode();
    }

    public async Task<SpeakerResponse?> GetSpeakerAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/api/Speaker/{id}");
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<SpeakerResponse>();
    }

    public async Task<List<SpeakerResponse>> GetSpeakersAsync()
    {
        var response = await _httpClient.GetAsync("/api/Speaker");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<SpeakerResponse>>() ?? new();
    }

    public async Task PutSessionAsync(Session session)
    {
        var response = await _httpClient.PutAsJsonAsync($"/api/Session/{session.Id}", session);
        response.EnsureSuccessStatusCode();
    }

    public async Task<List<SearchResult>> SearchAsync(string term)
    {
        var response = await _httpClient.GetAsync($"/api/search/{term}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<SearchResult>>() ?? new();
    }

    public async Task AddSessionToAttendeeAsync(string name, int sessionId)
    {
        var response = await _httpClient.PostAsync($"/api/attendees/{name}/session/{sessionId}", null);

        response.EnsureSuccessStatusCode();
    }

    public async Task RemoveSessionFromAttendeeAsync(string name, int sessionId)
    {
        var response = await _httpClient.DeleteAsync($"/api/attendees/{name}/session/{sessionId}");

        response.EnsureSuccessStatusCode();
    }

    public async Task<List<SessionResponse>> GetSessionsByAttendeeAsync(string name)
    {
        var response = await _httpClient.GetAsync($"/api/attendees/{name}/sessions");

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<SessionResponse>>();
    }
}