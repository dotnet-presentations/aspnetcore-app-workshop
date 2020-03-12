using System.Collections.Generic;

namespace ConferenceDTO
{
    public class SpeakerResponse : Speaker
    {
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
