using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceDTO
{
    public class ConferenceResponse : Conference
    {
        public ICollection<Session> Sessions { get; set; }

        public ICollection<Track> Tracks { get; set; }

        public ICollection<Speaker> Speakers { get; set; }
    }
}
