using Microsoft.EntityFrameworkCore;
using BackEnd.Data;

namespace BackEnd.Endpoints;

public static class SpeakerEndpoints
{
    public static void MapSpeakerEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Speaker", async (ApplicationDbContext db) =>
        {
            return await db.Speakers.AsNoTracking()
                            .Include(s => s.SessionSpeakers)
                            .ThenInclude(ss => ss.Session)
                            .Select(s => s.MapSpeakerResponse())
                            .ToListAsync();
        })
        .WithTags("Speaker")
        .WithName("GetAllSpeakers")
        .Produces<List<ConferenceDTO.Speaker>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Speaker/{id}", async (int Id, ApplicationDbContext db) =>
        {
            return await db.Speakers.AsNoTracking()
                            .Include(s => s.SessionSpeakers)
                            .ThenInclude(ss => ss.Session)
                            .SingleOrDefaultAsync(s => s.Id == Id)
                is Speaker model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithTags("Speaker")
        .WithName("GetSpeakerById")
        .Produces<ConferenceDTO.Speaker>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}