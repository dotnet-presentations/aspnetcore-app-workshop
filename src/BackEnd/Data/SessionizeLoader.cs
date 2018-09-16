using BackEnd.Data;
using BackEnd.ImportMapping;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BackEnd
{
    public class SessionizeLoader : BaseDataLoader
    {

        public SessionizeLoader(IServiceProvider services) : base(services)
        {
            // this.SaveData = false;
        }

        protected override void LoadFormattedData(ApplicationDbContext db)
        {
            string json = File.ReadAllText(Filename);

            //var blah = new RootObject().rooms[0].sessions[0].speakers[0].name;

            var addedSpeakers = new Dictionary<string, Speaker>();
            var addedTracks = new Dictionary<string, Track>();
            var addedTags = new Dictionary<string, Tag>();

            var root = JsonConvert.DeserializeObject<List<RootObject>>(json);

            foreach (var date in root)
            {
                foreach (var room in date.rooms)
                {
                    if (!addedTracks.ContainsKey(room.name))
                    {
                        var thisTrack = new Track { Name = room.name, Conference = this.Conference };
                        db.Tracks.Add(thisTrack);
                        addedTracks.Add(thisTrack.Name, thisTrack);
                    }

                    foreach (var thisSession in room.sessions)
                    {
                        foreach (var speaker in thisSession.speakers)
                        {
                            if (!addedSpeakers.ContainsKey(speaker.name))
                            {
                                var thisSpeaker = new Speaker { Name = speaker.name };
                                db.Speakers.Add(thisSpeaker);
                                addedSpeakers.Add(thisSpeaker.Name, thisSpeaker);
                                Console.WriteLine(thisSpeaker.Name);
                            }
                        }

                        foreach (var category in thisSession.categories)
                        {
                            if (!addedTags.ContainsKey(category.name))
                            {
                                var thisTag = new Tag { Name = category.name };
                                db.Tags.Add(thisTag);
                                addedTags.Add(thisTag.Name, thisTag);
                                Console.WriteLine(thisTag.Name);
                            }
                        }

                        var session = new Session
                        {
                            Conference = Conference,
                            Title = thisSession.title,
                            StartTime = thisSession.startsAt,
                            EndTime = thisSession.endsAt,
                            Track = addedTracks[room.name],
                            Abstract = thisSession.description
                        };

                        session.SessionSpeakers = new List<SessionSpeaker>();
                        foreach (var sp in thisSession.speakers)
                        {
                            session.SessionSpeakers.Add(new SessionSpeaker
                            {
                                Session = session,
                                Speaker = addedSpeakers[sp.name]
                            });
                        }

                        db.Sessions.Add(session);
                    }
                }
            }
        }
    }
}

namespace BackEnd.ImportMapping
{
    //[Browsable(false)]
    //[EditorBrowsable(EditorBrowsableState.Never)]
    public class RootObject
    {
        public DateTime date { get; set; }
        public List<Room> rooms { get; set; }
        public List<TimeSlot> timeSlots { get; set; }
    }

    public class ImportSpeaker
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<object> categoryItems { get; set; }
        public int sort { get; set; }
    }

    public class ImportSession
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime startsAt { get; set; }
        public DateTime endsAt { get; set; }
        public bool isServiceSession { get; set; }
        public bool isPlenumSession { get; set; }
        public List<ImportSpeaker> speakers { get; set; }
        public List<Category> categories { get; set; }
        public int roomId { get; set; }
        public string room { get; set; }
    }

    public class Room
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<ImportSession> sessions { get; set; }
        public bool hasOnlyPlenumSessions { get; set; }
    }

    public class TimeSlot
    {
        public string slotStart { get; set; }
        public List<Room> rooms { get; set; }
    }
}