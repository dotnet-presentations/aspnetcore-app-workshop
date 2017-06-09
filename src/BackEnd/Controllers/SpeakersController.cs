using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class SpeakersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SpeakersController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetSpeakers()
        {
            var speakers = await _db.Speakers.AsNoTracking()
                                             .Include(s => s.SessionSpeakers)
                                             .ToListAsync();
            // TODO: Use AutoMapper
            var result = speakers.Select(s => new ConferenceDTO.SpeakerResponse
            {
                ID = s.ID,
                Name = s.Name,
                Bio = s.Bio,
                WebSite = s.WebSite,
                Sessions = s.SessionSpeakers?
                    .Select(ss =>
                        new ConferenceDTO.Session
                        {
                            ID = ss.SessionId,
                            Title = ss.Session.Title
                        })
                    .ToList()
            });
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSpeaker([FromRoute]int id)
        {
            var speaker = await _db.Speakers.AsNoTracking()
                                            .Include(s => s.SessionSpeakers)
                                            .SingleOrDefaultAsync(s => s.ID == id);

            if (speaker == null)
            {
                return NotFound();
            }

            // TODO: Use AutoMapper
            var result = new ConferenceDTO.SpeakerResponse
            {
                ID = speaker.ID,
                Name = speaker.Name,
                Bio = speaker.Bio,
                WebSite = speaker.WebSite,
                Sessions = speaker.SessionSpeakers?
                    .Select(ss =>
                        new ConferenceDTO.Session
                        {
                            ID = ss.SessionId,
                            Title = ss.Session.Title
                        })
                    .ToList()
            };
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpeaker([FromBody]ConferenceDTO.Speaker input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Use AutoMapper
            var speaker = new Speaker
            {
                Name = input.Name,
                WebSite = input.WebSite
            };

            _db.Speakers.Add(speaker);
            await _db.SaveChangesAsync();

            // TODO: Use AutoMapper
            var result = new ConferenceDTO.SpeakerResponse
            {
                ID = speaker.ID,
                Name = speaker.Name,
                Bio = speaker.Bio,
                WebSite = speaker.WebSite,
                Sessions = speaker.SessionSpeakers?
                    .Select(ss =>
                        new ConferenceDTO.Session
                        {
                            ID = ss.SessionId
                        })
                        .ToList()
            };

            return CreatedAtAction(nameof(GetSpeaker), new { id = speaker.ID }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSpeaker([FromRoute]int id, [FromBody]ConferenceDTO.Speaker input)
        {
            var speaker = await _db.FindAsync<Speaker>(id);

            if (speaker == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Use AutoMapper
            speaker.Name = input.Name;
            speaker.WebSite = input.WebSite;

            // TODO: Handle exceptions, e.g. concurrency
            await _db.SaveChangesAsync();

            // TODO: Use AutoMapper
            var result = new ConferenceDTO.SpeakerResponse
            {
                ID = speaker.ID,
                Name = speaker.Name,
                Bio = speaker.Bio,
                WebSite = speaker.WebSite,
                Sessions = speaker?.SessionSpeakers
                    .Select(ss =>
                        new ConferenceDTO.Session
                        {
                            ID = ss.SessionId
                        })
                    .ToList()
            };

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSpeaker([FromRoute]int id)
        {
            var speaker = await _db.FindAsync<Speaker>(id);

            if (speaker == null)
            {
                return NotFound();
            }

            _db.Remove(speaker);

            // TODO: Handle exceptions, e.g. concurrency
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
