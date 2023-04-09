using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using ConferenceDTO;

namespace BackEnd.Endpoints;

public static class AttendeeEndpoints
{
    public static void MapAttendeeEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Attendee/{username}", async (string username, ApplicationDbContext db) =>
        {
            var attendee = await db.Attendees.Include(a => a.SessionsAttendees)
                .ThenInclude(sa => sa.Session)
                .SingleOrDefaultAsync(a => a.UserName == username);

            return await db.Attendees.Include(a => a.SessionsAttendees)
                .ThenInclude(sa => sa.Session)
                .SingleOrDefaultAsync(a => a.UserName == username)
                is Data.Attendee model
                    ? Results.Ok(model.MapAttendeeResponse())
                    : Results.NotFound();
        })
        .WithTags("Attendee")
        .WithName("GetAttendee")
        .Produces<AttendeeResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapGet("/api/Attendee/{username}/Sessions",
        async (string username, ApplicationDbContext db) =>
        {
            var sessions = await db.Sessions.AsNoTracking()
                                                .Include(s => s.Track)
                                                .Include(s => s.SessionSpeakers)
                                                    .ThenInclude(ss => ss.Speaker)
                                                .Where(s => s.SessionAttendees.Any(sa => sa.Attendee.UserName == username))
                                                .Select(m => m.MapSessionResponse())
                                                .ToListAsync();

            if (sessions is List<Data.Session>)
            {
                return Results.Ok(sessions);
            }
            return Results.NotFound();
        })
        .WithTags("Attendee")
        .WithName("GetAllSessionsForAttendee")
        .Produces<List<Data.Session>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPost("/api/Attendee/", async (ConferenceDTO.Attendee input, ApplicationDbContext db) =>
        {
            // Check if the attendee already exists
            var existingAttendee = await db.Attendees
                .Where(a => a.UserName == input.UserName)
                .FirstOrDefaultAsync();

            if (existingAttendee == null)
            {
                var attendee = new Data.Attendee
                {
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    UserName = input.UserName,
                    EmailAddress = input.EmailAddress
                };

                db.Attendees.Add(attendee);
                await db.SaveChangesAsync();

                var result = attendee.MapAttendeeResponse();

                return Results.Created($"/api/Attendee/{attendee.UserName}", result);
            }
            else
            {
                return Results.Conflict();
            }
        })
        .WithTags("Attendee")
        .WithName("CreateAttendee")
        .Produces<AttendeeResponse>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status409Conflict);

        routes.MapPost("/api/Attendee/{username}/Session/{sessionId}",
            async (string username, int sessionId, ApplicationDbContext db) =>
        {
            var attendee = await db.Attendees.Include(a => a.SessionsAttendees)
                                .ThenInclude(sa => sa.Session)
                                .SingleOrDefaultAsync(a => a.UserName == username);

            if (attendee == null)
            {
                return Results.NotFound(new { Attendee = username });
            }

            var session = await db.Sessions.FindAsync(sessionId);

            if (session == null)
            {
                return Results.NotFound(new { Session = sessionId });
            }

            attendee.SessionsAttendees.Add(new SessionAttendee
            {
                AttendeeId = attendee.Id,
                SessionId = sessionId
            });

            await db.SaveChangesAsync();

            var result = attendee.MapAttendeeResponse();
            return Results.Created($"/api/Attendee/{result.UserName}", result);
        })
        .WithTags("Attendee")
        .WithName("AddAttendeeSession")
        .Produces<AttendeeResponse>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapDelete("/api/Attendee/{username}/Session/{sessionId}",
            async (string username, int sessionId, ApplicationDbContext db) =>
            {
                var attendee = await db.Attendees.Include(a => a.SessionsAttendees)
                    .SingleOrDefaultAsync(a => a.UserName == username);

                if (attendee is Data.Attendee)
                {
                    var session = await db.Sessions.FindAsync(sessionId);

                    if (session is Data.Session)
                    {
                        var sessionAttendee = attendee.SessionsAttendees
                            .FirstOrDefault(sa => sa.SessionId == sessionId);

                        if(sessionAttendee is SessionAttendee)
                        attendee.SessionsAttendees.Remove(sessionAttendee);

                        await db.SaveChangesAsync();
                        return Results.Ok();
                    }
                }
                return Results.NotFound();
            })
        .WithTags("Attendee")
        .WithName("RemoveSessionFromAttendee")
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}