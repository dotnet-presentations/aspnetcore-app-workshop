using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceDTO;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace FrontEnd.Pages
{
    public class SessionModel : PageModel
    {
        private readonly IApiClient _apiClient;
        private readonly IAuthorizationService _authz;

        public SessionModel(IApiClient apiClient, IAuthorizationService authz)
        {
            _apiClient = apiClient;
            _authz = authz;
        }

        public SessionResponse Session { get; set; }

        public bool IsAdmin { get; set; }

        public async Task OnGet(int id)
        {
            IsAdmin = await _authz.AuthorizeAsync(User, "Admin");

            Session = await _apiClient.GetSessionAsync(id);

            // Do something if it's null
        }
    }
}
