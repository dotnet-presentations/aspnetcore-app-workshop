namespace BackEnd.Data;

public class SessionSpeaker
{
    public int SessionId { get; set; }

    public Session Session { get; set; } = null!;

    public int SpeakerId { get; set; }

    public Speaker Speaker { get; set; } = null!;
}