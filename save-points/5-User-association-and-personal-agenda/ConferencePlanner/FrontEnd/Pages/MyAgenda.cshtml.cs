using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceDTO;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;

namespace FrontEnd.Pages
{
    public class MyAgendaModel : IndexModel
    {
        public MyAgendaModel(IApiClient client, IAuthorizationService authz)
            : base(client, authz)
        {

        }

        protected override Task<List<SessionResponse>> GetSessionsAsync()
        {
            return _apiClient.GetSessionsByAttendeeAsync(User.Identity.Name);
        }
    }
}