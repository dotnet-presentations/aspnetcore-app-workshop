using System;
using System.Collections.Generic;
using System.IO;
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BackEnd
{
    public class SessionizeLoader : IDataLoader
    {
        public SessionizeLoader(IConfiguration configuration)
        {
            Filename = configuration["DataFile"];
            var conferenceName = configuration["ConferenceName"];
            Conference = new Conference { ID = 1, Name = conferenceName };
        }

        public string Filename { get; set; }
        public Conference Conference { get; set; }

        public void LoadData(ModelBuilder builder)
        {
            string json = File.ReadAllText(Filename);

            //var blah = new RootObject().rooms[0].sessions[0].speakers[0].name;

            var speakerIds = new List<string>(); //Maps Sessionize GUID to int ID
            var addedTracks = new Dictionary<int, Track>();
            var addedTags = new Dictionary<int, Tag>();

            var root = JsonConvert.DeserializeObject<List<RootObject>>(json);

            builder.Entity<Conference>().HasData(this.Conference);

            foreach (var date in root)
            {
                foreach (var room in date.rooms)
                {
                    if (!addedTracks.ContainsKey(room.id))
                    {
                        var thisTrack = new Track
                        {
                            TrackID = room.id,
                            Name = room.name,
                            ConferenceID = this.Conference.ID
                        };
                        builder.Entity<Track>().HasData(thisTrack);

                        addedTracks.Add(thisTrack.TrackID, thisTrack);
                    }

                    foreach (var thisSession in room.sessions)
                    {
                        foreach (var speaker in thisSession.speakers)
                        {
                            if (!speakerIds.Contains(speaker.id))
                            {
                                speakerIds.Add(speaker.id);
                                var thisSpeaker = new Speaker
                                {
                                    ID = speakerIds.IndexOf(speaker.id) + 1,
                                    Name = speaker.name
                                };
                                builder.Entity<Speaker>().HasData(thisSpeaker);
                            }
                        }

                        foreach (var category in thisSession.categories)
                        {
                            if (!addedTags.ContainsKey(category.id))
                            {
                                var thisTag = new Tag { ID = category.id, Name = category.name };
                                builder.Entity<Tag>().HasData(thisTag);
                                addedTags.Add(thisTag.ID, thisTag);
                            }
                        }

                        var session = new Session
                        {
                            ID = thisSession.id,
                            ConferenceID = this.Conference.ID,
                            TrackId = addedTracks[room.id].TrackID,
                            Title = thisSession.title,
                            StartTime = thisSession.startsAt,
                            EndTime = thisSession.endsAt,
                            Abstract = thisSession.description
                        };

                        builder.Entity<Session>()
                            .HasData(session);

                        foreach (var sp in thisSession.speakers)
                        {
                            builder.Entity<SessionSpeaker>().HasData(
                                new SessionSpeaker
                                {
                                    SessionId = session.ID,
                                    SpeakerId = speakerIds.IndexOf(sp.id) + 1
                                });
                        }
                    }
                }
            }
        }

        private class RootObject
        {
            public DateTime date { get; set; }
            public List<Room> rooms { get; set; }
            public List<TimeSlot> timeSlots { get; set; }
        }

        private class ImportSpeaker
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        private class Category
        {
            public int id { get; set; }
            public string name { get; set; }
            public List<object> categoryItems { get; set; }
            public int sort { get; set; }
        }

        private class ImportSession
        {
            public int id { get; set; }
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

        private class Room
        {
            public int id { get; set; }
            public string name { get; set; }
            public List<ImportSession> sessions { get; set; }
            public bool hasOnlyPlenumSessions { get; set; }
        }

        private class TimeSlot
        {
            public string slotStart { get; set; }
            public List<Room> rooms { get; set; }
        }
    }
}