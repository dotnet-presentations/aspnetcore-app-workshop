using System.Text.Json;

namespace BackEnd.Data;

public class TechoramaDataLoader : DataLoader
{
    public async override Task LoadDataAsync(Stream fileStream, ApplicationDbContext db)
    {
        var addedSpeakers = new Dictionary<string, Speaker>();
        var addedTracks = new Dictionary<string, Track>();

        var reader = new StreamReader(fileStream);
        var text = await reader.ReadToEndAsync();

        foreach (TechoramaSession item in
            JsonSerializer.Deserialize<List<TechoramaSession>>(text) ?? new())
        {
            //These are all required to add to the schedule
            var speakers = item.Speakers?.Split(',');
            if (speakers is null
                || item.TimeSlot is null
                || item.Date is null
                || item.Track is null)
            { 
                continue; 
            }

            foreach (var thisSpeakerName in speakers)
            {
                var theseSpeakers = new List<Speaker>();

                if (!addedSpeakers.ContainsKey(thisSpeakerName))
                {
                    var thisSpeaker = new Speaker { Name = thisSpeakerName };
                    db.Speakers.Add(thisSpeaker);
                    addedSpeakers.Add(thisSpeakerName, thisSpeaker);
                    theseSpeakers.Add(thisSpeaker);
                    Console.WriteLine(thisSpeakerName);
                    theseSpeakers.Add(thisSpeaker);
                }

                if (!addedTracks.ContainsKey(item.Track))
                {
                    var thisTrack = new Track { Name = item.Track };
                    db.Tracks.Add(thisTrack);
                    addedTracks.Add(item.Track, thisTrack);
                }
            }

            //"08:45 - 09:45"
            string[] timeSlotParts = item.TimeSlot.Split(" - ");

            //24 May 2022 | 08:45 - 09:45"
            string date = item.Date.Split(" | ")[0];

            var session = new Session
            {
                Title = item.Title,
                StartTime = DateTime.Parse($"{date} {timeSlotParts[0]}"),
                EndTime = DateTime.Parse($"{date} {timeSlotParts[1]}"),
                Track = addedTracks[item.Track],
                Abstract = item.Description
            };

            session.SessionSpeakers = new List<SessionSpeaker>();
            foreach (var sp in speakers)
            {
                session.SessionSpeakers.Add(new SessionSpeaker
                {
                    Session = session,
                    Speaker = addedSpeakers[sp]
                });
            }

            db.Sessions.Add(session);
        }
    }
}

public class TechoramaSession
{
    public string? Title { get; set; }
    public string? Room { get; set; }
    public int RoomInt { get; set; }
    public string? Slug { get; set; }
    public string? Day { get; set; }
    public string? TimeSlot { get; set; }
    public string? Date { get; set; }
    public string? Track { get; set; }
    public string? TrackSlug { get; set; }
    public string? Speakers { get; set; }
    public string? Description { get; set; }
}