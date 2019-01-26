using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Design;

namespace BackEnd.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDataLoader _loader;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDataLoader loader)
            : base(options)
        {
            _loader = loader;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendee>()
               .HasIndex(a => a.UserName)
               .IsUnique();

            // Ignore the computed property
            modelBuilder.Entity<Session>()
                    .Ignore(s => s.Duration);

            // Many-to-many: Conference <-> Attendee
            modelBuilder.Entity<ConferenceAttendee>()
                .HasKey(ca => new { ca.ConferenceID, ca.AttendeeID });

            // Many-to-many: Session <-> Attendee
            modelBuilder.Entity<SessionAttendee>()
                .HasKey(ca => new { ca.SessionID, ca.AttendeeID });

            // Many-to-many: Speaker <-> Session
            modelBuilder.Entity<SessionSpeaker>()
                .HasKey(ss => new { ss.SessionId, ss.SpeakerId});

            // Many-to-many: Session <-> Tag
            modelBuilder.Entity<SessionTag>()
                .HasKey(st => new { st.SessionID, st.TagID });

            _loader.LoadData(modelBuilder, "NDC_Sydney_2018.json", "NDC Sydney 2018");
        }

        public DbSet<Conference> Conferences { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Speaker> Speakers { get; set; }

        public DbSet<Attendee> Attendees { get; set; }
    }
}
