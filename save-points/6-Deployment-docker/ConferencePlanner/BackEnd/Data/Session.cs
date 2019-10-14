using System;
using System.Collections;
using System.Collections.Generic;

namespace BackEnd.Data
{
    public class Session : ConferenceDTO.Session
    {
        public virtual ICollection<SessionSpeaker> SessionSpeakers { get; set; }

        public virtual ICollection<SessionAttendee> SessionAttendees { get; set; }

        public Track Track { get; set; }
    }
}