using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ConferenceDTO;
using FrontEnd.Infrastructure;

namespace FrontEnd.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SessionResponse> GetSessionAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/sessions/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            
            // REVIEW: How do we handle errors
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<SessionResponse>();
        }

        public async Task<List<SessionResponse>> GetSessionsAsync()
        {
            var response = await _httpClient.GetAsync("/api/sessions");

            // REVIEW: How do we handle errors
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<SessionResponse>>();
        }
    }
}
