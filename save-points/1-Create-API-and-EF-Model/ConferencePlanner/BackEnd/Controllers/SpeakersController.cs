using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SpeakersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Speakers
        [HttpGet]
        public IEnumerable<Speaker> GetSpeakers()
        {
            return _context.Speakers;
        }

        // GET: api/Speakers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpeaker([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var speaker = await _context.Speakers.FindAsync(id);

            if (speaker == null)
            {
                return NotFound();
            }

            return Ok(speaker);
        }

        // PUT: api/Speakers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpeaker([FromRoute] int id, [FromBody] Speaker speaker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != speaker.ID)
            {
                return BadRequest();
            }

            _context.Entry(speaker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeakerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Speakers
        [HttpPost]
        public async Task<IActionResult> PostSpeaker([FromBody] Speaker speaker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Speakers.Add(speaker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpeaker", new { id = speaker.ID }, speaker);
        }

        // DELETE: api/Speakers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpeaker([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var speaker = await _context.Speakers.FindAsync(id);
            if (speaker == null)
            {
                return NotFound();
            }

            _context.Speakers.Remove(speaker);
            await _context.SaveChangesAsync();

            return Ok(speaker);
        }

        private bool SpeakerExists(int id)
        {
            return _context.Speakers.Any(e => e.ID == id);
        }
    }
}