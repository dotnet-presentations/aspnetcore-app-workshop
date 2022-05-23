namespace BackEnd.Data;

public class Session : ConferenceDTO.Session
{
    public virtual ICollection<SessionSpeaker> SessionSpeakers { get; set; } = null!;

    public virtual ICollection<SessionAttendee> SessionAttendees { get; set; } = null!;

    public Track Track { get; set; } = null!;
}