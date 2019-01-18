using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using Microsoft.AspNetCore.Http;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferencesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ConferencesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetConferences()
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetConference([FromRoute] int id)
        {
            var conference = await _db.FindAsync<Conference>(id);

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
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateConference([FromBody] ConferenceDTO.Conference input)
        {
            var conference = new Conference
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateConference([FromRoute]int id, [FromBody]ConferenceDTO.Conference input)
        {
            var conference = await _db.FindAsync<Conference>(id);

            if (conference == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            conference.Name = input.Name;

            await _db.SaveChangesAsync();

            var result = new ConferenceDTO.ConferenceResponse
            {
                ID = conference.ID,
                Name = conference.Name,
                //Sessions = ??,
                //Tracks = ??
                //Sessions = ??
            };

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteConference([FromRoute] int id)
        {
            var conference = await _db.FindAsync<Conference>(id);

            if (conference == null)
            {
                return NotFound();
            }

            _db.Remove(conference);

            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
