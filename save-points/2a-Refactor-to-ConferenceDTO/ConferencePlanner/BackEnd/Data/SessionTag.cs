using ConferenceDTO;

namespace BackEnd.Data
{
    public class SessionTag
    {
        public int SessionID { get; set; }

        public Session Session { get; set; }

        public int TagID { get; set; }

        public Tag Tag { get; set; }
    }
}