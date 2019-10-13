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
    public class SpeakersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public SpeakersController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<SpeakerResponse>>> GetSpeakers()
        {
            var speakers = await _db.Speakers.AsNoTracking()
                                             .Include(s => s.SessionSpeakers)
                                                .ThenInclude(ss => ss.Session)
                                             .Select(s => s.MapSpeakerResponse())
                                             .ToListAsync();

            return speakers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpeakerResponse>> GetSpeaker(int id)
        {
            var speaker = await _db.Speakers.AsNoTracking()
                                            .Include(s => s.SessionSpeakers)
                                                .ThenInclude(ss => ss.Session)
                                            .SingleOrDefaultAsync(s => s.Id == id);

            if (speaker == null)
            {
                return NotFound();
            }

            var result = speaker.MapSpeakerResponse();
            return result;
        }
    }
}
