using System.Collections.Generic;

namespace ConferenceDTO
{
    public class TagResponse : Tag
    {
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}