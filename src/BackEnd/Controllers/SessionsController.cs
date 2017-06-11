using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class SessionsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SessionsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sessions = await _db.Sessions.AsNoTracking()
                                             .Include(s => s.Track)
                                             .Include(s => s.SessionSpeakers)
                                                .ThenInclude(ss => ss.Speaker)
                                             .Include(s => s.SessionTags)
                                                .ThenInclude(st => st.Tag)
                                             .ToListAsync();

            var results = sessions.Select(s => new ConferenceDTO.SessionResponse
            {
                ID = s.ID,
                Title = s.Title,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                Tags = s?.SessionTags
                         .Select(t => new ConferenceDTO.Tag
                         {
                             ID = t.TagID,
                             Name = t.Tag.Name
                         })
                         .ToList(),
                Speakers = s?.SessionSpeakers
                             .Select(ss => new ConferenceDTO.Speaker
                             {
                                 ID = ss.SpeakerId,
                                 Name = ss.Speaker.Name
                             })
                             .ToList(),
                TrackId = s.TrackId,
                Track = new ConferenceDTO.Track
                {
                    TrackID = s?.TrackId ?? 0,
                    Name = s.Track?.Name
                },
                ConferenceID = s.ConferenceID,
                Abstract = s.Abstract
            });

            return Ok(results);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var session = await _db.Sessions.Include(s => s.Track)
                                            .Include(s => s.SessionSpeakers)
                                                .ThenInclude(ss => ss.Speaker)
                                            .Include(s => s.SessionTags)
                                                .ThenInclude(st => st.Tag)
                                            .SingleOrDefaultAsync(s => s.ID == id);

            if (session == null)
            {
                return NotFound();
            }

            var result = new ConferenceDTO.SessionResponse
            {
                ID = session.ID,
                Title = session.Title,
                StartTime = session.StartTime,
                EndTime = session.EndTime,
                Tags = session?.SessionTags
                               .Select(st => new ConferenceDTO.Tag
                               {
                                   ID = st.TagID,
                                   Name = st.Tag.Name
                               })
                               .ToList(),
                Speakers = session?.SessionSpeakers
                                   .Select(ss => new ConferenceDTO.Speaker
                                   {
                                       ID = ss.SpeakerId,
                                       Name = ss.Speaker.Name
                                   })
                                   .ToList(),
                TrackId = session.TrackId,
                Track = new Track
                {
                    TrackID = session?.TrackId ?? 0,
                    Name = session.Track?.Name
                },
                ConferenceID = session.ConferenceID,
                Abstract = session.Abstract
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ConferenceDTO.Session input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var session = new Session
            {
                Title = input.Title,
                ConferenceID = input.ConferenceID,
                StartTime = input.StartTime,
                EndTime = input.EndTime,
                Abstract = input.Abstract,
                TrackId = input.TrackId
            };

            _db.Sessions.Add(session);
            await _db.SaveChangesAsync();

            var result = new ConferenceDTO.SessionResponse
            {
                ID = session.ID,
                Title = session.Title,
                StartTime = session.StartTime,
                EndTime = session.EndTime,
                TrackId = session.TrackId,
                ConferenceID = session.ConferenceID
            };

            return CreatedAtAction(nameof(Get), new { id = result.ID }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody]ConferenceDTO.Session input)
        {
            var session = await _db.Sessions.FindAsync(id);

            if (session == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            session.ID = input.ID;
            session.Title = input.Title;
            session.Abstract = input.Abstract;
            session.StartTime = input.StartTime;
            session.EndTime = input.EndTime;
            session.TrackId = input.TrackId;
            session.ConferenceID = input.ConferenceID;

            await _db.SaveChangesAsync();

            var result = new ConferenceDTO.SessionResponse
            {
                ID = session.ID,
                Title = session.Title,
                Abstract = session.Abstract,
                StartTime = session.StartTime,
                EndTime = session.EndTime,
                TrackId = session.TrackId,
                ConferenceID = session.ConferenceID
            };

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var session = await _db.Sessions.FindAsync(id);

            if (session == null)
            {
                return NotFound();
            }

            _db.Sessions.Remove(session);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
