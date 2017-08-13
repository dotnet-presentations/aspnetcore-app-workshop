using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceDTO;
using FrontEnd.Services;

namespace FrontEnd.Pages
{
    public class MyAgendaModel : IndexModel
    {
        public MyAgendaModel(IApiClient client)
            : base(client)
        {

        }

        protected override Task<List<SessionResponse>> GetSessionsAsync()
        {
            return _apiClient.GetSessionsByAttendeeAsync(User.Identity.Name);
        }
    }
}