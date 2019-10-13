namespace ConferenceDTO
{
    public class SearchResult
    {
        public SearchResultType Type { get; set; }

        public SessionResponse Session { get; set; }

        public SpeakerResponse Speaker { get; set; }
    }

    public enum SearchResultType
    {
        Session,
        Speaker
    }
}