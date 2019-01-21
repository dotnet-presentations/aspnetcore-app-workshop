using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using ConferenceDTO;
using Microsoft.AspNetCore.Authorization;

namespace BackEnd.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConferencesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ConferencesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<ConferenceResponse>> GetConferences()
        {
            var conferences = await _db.Conferences.AsNoTracking().ToListAsync();

            var result = conferences.Select(s => new ConferenceDTO.ConferenceResponse
            {
                ID = s.ID,
                Name = s.Name,
                //Sessions = ??,
                //Tracks = ??
                //Sessions = ??
            });
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ConferenceResponse>> GetConference(int id)
        {
            var conference = await _db.FindAsync<Data.Conference>(id);

            if (conference == null)
            {
                return NotFound();
            }
            
            var result = new ConferenceDTO.ConferenceResponse
            {
                ID = conference.ID,
                Name = conference.Name,
                //Sessions = ??,
                //Tracks = ??
                //Sessions = ??
            };
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<ConferenceResponse>> CreateConference(ConferenceDTO.Conference input)
        {
            var conference = new Data.Conference
            {
                Name = input.Name
            };

            _db.Conferences.Add(conference);
            await _db.SaveChangesAsync();

            var result = new ConferenceDTO.ConferenceResponse
            {
                ID = conference.ID,
                Name = conference.Name,
                //Sessions = ??,
                //Tracks = ??
                //Sessions = ??
            };

            return CreatedAtAction(nameof(GetConference), new { id = conference.ID }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ConferenceResponse>> PutConference(int id, ConferenceDTO.Conference input)
        {
            var conference = await _db.FindAsync<Data.Conference>(id);

            if (conference == null)
            {
                return NotFound();
            }
            
            conference.Name = input.Name;

            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteConference(int id)
        {
            var conference = await _db.FindAsync<Data.Conference>(id);

            if (conference == null)
            {
                return NotFound();
            }

            _db.Remove(conference);

            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
