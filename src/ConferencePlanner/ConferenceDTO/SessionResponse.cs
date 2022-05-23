namespace ConferenceDTO;

public class SessionResponse : Session
{
    public Track Track { get; set; } = null!;

    public List<Speaker> Speakers { get; set; } = new List<Speaker>();
}