using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BackEnd.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BackEnd
{
    public class DevIntersectionLoader : DataLoader
    {
        public override async Task LoadDataAsync(Stream fileStream, ApplicationDbContext db)
        {
            var reader = new JsonTextReader(new StreamReader(fileStream));

            var speakerNames = new Dictionary<string, Speaker>();
            var tracks = new Dictionary<string, Track>();

            JArray doc = await JArray.LoadAsync(reader);

            foreach (JObject item in doc)
            {
                var theseSpeakers = new List<Speaker>();
                foreach (var thisSpeakerName in item["speakerNames"])
                {
                    if (!speakerNames.ContainsKey(thisSpeakerName.Value<string>()))
                    {
                        var thisSpeaker = new Speaker { Name = thisSpeakerName.Value<string>() };
                        db.Speakers.Add(thisSpeaker);
                        speakerNames.Add(thisSpeakerName.Value<string>(), thisSpeaker);
                        Console.WriteLine(thisSpeakerName.Value<string>());
                    }
                    theseSpeakers.Add(speakerNames[thisSpeakerName.Value<string>()]);
                }

                var theseTracks = new List<Track>();
                foreach (var thisTrackName in item["trackNames"])
                {
                    if (!tracks.ContainsKey(thisTrackName.Value<string>()))
                    {
                        var thisTrack = new Track { Name = thisTrackName.Value<string>() };
                        db.Tracks.Add(thisTrack);
                        tracks.Add(thisTrackName.Value<string>(), thisTrack);
                    }
                    theseTracks.Add(tracks[thisTrackName.Value<string>()]);
                }

                var session = new Session
                {
                    Title = item["title"].Value<string>(),
                    StartTime = item["startTime"].Value<DateTime>(),
                    EndTime = item["endTime"].Value<DateTime>(),
                    Track = theseTracks[0],
                    Abstract = item["abstract"].Value<string>()
                };

                session.SessionSpeakers = new List<SessionSpeaker>();
                foreach (var sp in theseSpeakers)
                {
                    session.SessionSpeakers.Add(new SessionSpeaker
                    {
                        Session = session,
                        Speaker = sp
                    });
                }

                db.Sessions.Add(session);
            }
        }
    }
}

