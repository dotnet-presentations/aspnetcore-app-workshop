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
            var speakers = await _db.Speakers.AsNoTracking().ToListAsync();
            // TODO: Use AutoMapper
            var result = speakers.Select(s => new ConferenceDTO.Speaker
            {
                SpeakerID = s.SpeakerID,
                Name = s.Name, 
                Bio = s.Bio,
                WebSite = s.WebSite,
                //Sessions = ??
            });
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSpeaker(int id)
        {
            var speaker = await _db.FindAsync<Speaker>(id);

            if (speaker == null)
            {
                return NotFound();
            }
            
            // TODO: Use AutoMapper
            var result = new ConferenceDTO.Speaker
            {
                SpeakerID = speaker.SpeakerID,
                Name = speaker.Name,
                Bio = speaker.Bio,
                WebSite = speaker.WebSite,
                //Sessions = ??
            };
            return Ok(speaker);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpeaker(ConferenceDTO.Speaker input)
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
            var result = new ConferenceDTO.Speaker
            {
                SpeakerID = speaker.SpeakerID,
                Name = speaker.Name,
                Bio = speaker.Bio,
                WebSite = speaker.WebSite
            };

            return CreatedAtAction(nameof(GetSpeaker), new { id = speaker.SpeakerID }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSpeaker(int id, ConferenceDTO.Speaker input)
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
            var result = new ConferenceDTO.Speaker
            {
                SpeakerID = speaker.SpeakerID,
                Name = speaker.Name,
                Bio = speaker.Bio,
                WebSite = speaker.WebSite
            };

            return Ok(result);
        }
    }
}
