using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using ConferenceDTO;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SessionsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<SessionResponse>>> Get()
        {
            var sessions = await _db.Sessions.AsNoTracking()
                                             .Include(s => s.Track)
                                             .Include(s => s.SessionSpeakers)
                                                .ThenInclude(ss => ss.Speaker)
                                             .Include(s => s.SessionTags)
                                                .ThenInclude(st => st.Tag)
                                             .Select(m => m.MapSessionResponse())
                                             .ToListAsync();
            return sessions;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SessionResponse>> Get(int id)
        {
            var session = await _db.Sessions.AsNoTracking()
                                            .Include(s => s.Track)
                                            .Include(s => s.SessionSpeakers)
                                                .ThenInclude(ss => ss.Speaker)
                                            .Include(s => s.SessionTags)
                                                .ThenInclude(st => st.Tag)
                                            .SingleOrDefaultAsync(s => s.ID == id);

            if (session == null)
            {
                return NotFound();
            }

            return session.MapSessionResponse();
        }

        [HttpPost]
        public async Task<ActionResult<SessionResponse>> Post(ConferenceDTO.Session input)
        {
            var session = new Data.Session
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

            var result = session.MapSessionResponse();

            return CreatedAtAction(nameof(Get), new { id = result.ID }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, ConferenceDTO.Session input)
        {
            var session = await _db.Sessions.FindAsync(id);

            if (session == null)
            {
                return NotFound();
            }

            session.ID = input.ID;
            session.Title = input.Title;
            session.Abstract = input.Abstract;
            session.StartTime = input.StartTime;
            session.EndTime = input.EndTime;
            session.TrackId = input.TrackId;
            session.ConferenceID = input.ConferenceID;

            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<SessionResponse>> Delete(int id)
        {
            var session = await _db.Sessions.FindAsync(id);

            if (session == null)
            {
                return NotFound();
            }

            _db.Sessions.Remove(session);
            await _db.SaveChangesAsync();

            return session.MapSessionResponse();
        }
    }
}
