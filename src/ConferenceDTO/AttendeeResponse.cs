using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceDTO
{
    public class AttendeeResponse : Attendee
    {
        public ICollection<Conference> Conferences { get; set; }

        public ICollection<Session> Sessions { get; set; }
    }
}
