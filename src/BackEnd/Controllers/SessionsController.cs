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

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sessions = await _db.Sessions.Include(s => s.SessionSpeakers).AsNoTracking().ToListAsync();

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
                            }).ToList(),
                Speakers = s?.SessionSpeakers
                               .Select(ss => new ConferenceDTO.Speaker
                               {
                                   ID = ss.SpeakerId,
                                   Name = ss.Speaker.Name
                               })
                               .ToList(),
                TrackId = s.TrackId,
                ConferenceID = s.ConferenceID,
                Abstract = s.Abstract
            });

            return Ok(sessions);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var session = await _db.Sessions.Include(s => s.SessionSpeakers)
                                            .Include(s => s.SessionTags)
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
                            }).ToList(),
                Speakers = session?.SessionSpeakers
                               .Select(ss => new ConferenceDTO.Speaker
                               {
                                   ID = ss.SpeakerId,
                                   Name = ss.Speaker.Name
                               })
                               .ToList(),
                TrackId = session.TrackId,
                ConferenceID = session.ConferenceID,
                Abstract = session.Abstract
            };

            return Ok(session);
        }

        // POST api/values
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

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ConferenceDTO.Session input)
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
            session.StartTime = input.StartTime;
            session.EndTime = input.EndTime;
            session.TrackId = input.TrackId;
            session.ConferenceID = input.ConferenceID;

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

            return Ok(result);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
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
