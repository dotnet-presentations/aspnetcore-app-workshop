using System.Collections.Generic;

namespace ConferenceDTO
{
    public class AttendeeResponse : Attendee
    {
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
