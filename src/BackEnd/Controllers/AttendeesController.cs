using System.Threading.Tasks;
using BackEnd.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd
{
    [Route("/api/[controller]")]
    public class AttendeesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AttendeesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> Get(string username)
        {
            var attendee = await _db.Attendees.SingleOrDefaultAsync(a => a.UserName == username);

            if (attendee == null)
            {
                return NotFound();
            }

            var result = attendee.MapAttendeeResponse();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ConferenceDTO.Attendee input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attendee = new Attendee
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                UserName = input.UserName
            };

            _db.Attendees.Add(attendee);
            await _db.SaveChangesAsync();

            var result = attendee.MapAttendeeResponse();

            return CreatedAtAction(nameof(Get), new { username = result.UserName }, result);
        }
    }
}