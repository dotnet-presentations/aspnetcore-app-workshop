using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceDTO
{
    public class SessionResponse : Session
    {
        public Track Track { get; set; }

        public List<Speaker> Speakers { get; set; } = new List<Speaker>();
    }
}
