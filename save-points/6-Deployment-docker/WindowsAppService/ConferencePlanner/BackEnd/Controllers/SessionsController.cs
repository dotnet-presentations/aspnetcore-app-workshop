using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using ConferenceDTO;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sessions
        [HttpGet]
        public async Task<ActionResult<List<SessionResponse>>> GetSessions()
        {
            var sessions = await _context.Sessions.AsNoTracking()
                                                  .Include(s => s.Track)
                                                  .Include(s => s.SessionSpeakers)
                                                      .ThenInclude(ss => ss.Speaker)
                                                  .Select(m => m.MapSessionResponse())
                                                  .ToListAsync();
            return sessions;
        }

        // GET: api/Sessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SessionResponse>> Get(int id)
        {
            var session = await _context.Sessions.AsNoTracking()
                                                 .Include(s => s.Track)
                                                 .Include(s => s.SessionSpeakers)
                                                     .ThenInclude(ss => ss.Speaker)
                                                 .SingleOrDefaultAsync(s => s.Id == id);

            if (session == null)
            {
                return NotFound();
            }

            return session.MapSessionResponse();
        }

        // PUT: api/Sessions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSession(int id, ConferenceDTO.Session input)
        {
            var session = await _context.Sessions.FindAsync(id);

            if (session == null)
            {
                return NotFound();
            }

            session.Id = input.Id;
            session.Title = input.Title;
            session.Abstract = input.Abstract;
            session.StartTime = input.StartTime;
            session.EndTime = input.EndTime;
            session.TrackId = input.TrackId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Sessions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SessionResponse>> PostSession(ConferenceDTO.Session input)
        {
            var session = new Data.Session
            {
                Title = input.Title,
                StartTime = input.StartTime,
                EndTime = input.EndTime,
                Abstract = input.Abstract,
                TrackId = input.TrackId
            };

            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();

            var result = session.MapSessionResponse();

            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        // DELETE: api/Sessions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SessionResponse>> DeleteSession(int id)
        {
            var session = await _context.Sessions.FindAsync(id);

            if (session == null)
            {
                return NotFound();
            }

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();

            return session.MapSessionResponse();
        }

        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var loader = new SessionizeLoader();
            using (var stream = file.OpenReadStream())
            {
                await loader.LoadDataAsync(stream, _context);
            }

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
