using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
namespace BackEnd;

public static class SpeakerEndpoints
{
    public static void MapSpeakerEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Speaker", async (ApplicationDbContext db) =>
        {
            return await db.Speakers.ToListAsync();
        })
        .WithTags("Speaker")
        .WithName("GetAllSpeakers")
        .Produces<List<Speaker>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Speaker/{id}", async (int Id, ApplicationDbContext db) =>
        {
            return await db.Speakers.FindAsync(Id)
                is Speaker model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithTags("Speaker")
		.WithName("GetSpeakerById")
        .Produces<Speaker>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Speaker/{id}", async (int Id, Speaker speaker, ApplicationDbContext db) =>
        {
            var foundModel = await db.Speakers.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithTags("Speaker")
		.WithName("UpdateSpeaker")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Speaker/", async (Speaker speaker, ApplicationDbContext db) =>
        {
            db.Speakers.Add(speaker);
            await db.SaveChangesAsync();
            return Results.Created($"/Speakers/{speaker.Id}", speaker);
        })
        .WithTags("Speaker")
		.WithName("CreateSpeaker")
        .Produces<Speaker>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Speaker/{id}", async (int Id, ApplicationDbContext db) =>
        {
            if (await db.Speakers.FindAsync(Id) is Speaker speaker)
            {
                db.Speakers.Remove(speaker);
                await db.SaveChangesAsync();
                return Results.Ok(speaker);
            }

            return Results.NotFound();
        })
        .WithTags("Speaker")
		.WithName("DeleteSpeaker")
        .Produces<Speaker>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
