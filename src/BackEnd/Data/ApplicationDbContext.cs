using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-many: Conference <-> Attendee
            modelBuilder.Entity<ConferenceAttendee>()
                .HasKey(ca => new { ca.ConferenceID, ca.AttendeeID });

            modelBuilder.Entity<ConferenceAttendee>()
                .HasOne(ca => ca.Conference)
                .WithMany(c => c.ConferenceAttendees)
                .HasForeignKey(ca => ca.ConferenceID);

            modelBuilder.Entity<ConferenceAttendee>()
                .HasOne(ca => ca.Attendee)
                .WithMany(a => a.ConferenceAttendees)
                .HasForeignKey(ca => ca.AttendeeID);

            // Many-to-many: Speaker <-> Session
            modelBuilder.Entity<SessionSpeaker>()
                .HasKey(ss => new { ss.SessionId, ss.SpeakerId});

            modelBuilder.Entity<SessionSpeaker>()
                .HasOne(ss => ss.Session)
                .WithMany(s => s.SessionSpeakers)
                .HasForeignKey(ss => ss.SessionId);

            modelBuilder.Entity<SessionSpeaker>()
                .HasOne(ss => ss.Speaker)
                .WithMany(s => s.SessionSpeakers)
                .HasForeignKey(ss => ss.SpeakerId);

            // Many-to-many: Session <-> Tag
            modelBuilder.Entity<SessionTag>()
                .HasKey(st => new { st.SessionID, st.TagID });

            modelBuilder.Entity<SessionTag>()
                .HasOne(st => st.Session)
                .WithMany(s => s.SessionTags)
                .HasForeignKey(st => st.SessionID);

            modelBuilder.Entity<SessionTag>()
                .HasOne(st => st.Tag)
                .WithMany(t => t.SessionTags)
                .HasForeignKey(st => st.TagID);
        }

        public DbSet<Conference> Conferences { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Speaker> Speakers { get; set; }

        public DbSet<Attendee> Attendees { get; set; }
    }

    public class ApplicationDbContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create(string[] args) =>
            Program.BuildWebHost(args).Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }
}
