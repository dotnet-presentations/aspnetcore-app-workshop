using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Data;
using ConferenceDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public SearchController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult<List<SearchResult>>> Search(SearchTerm term)
        {
            var query = term.Query;
            var sessionResults = await _db.Sessions.Include(s => s.Track)
                                                   .Include(s => s.SessionSpeakers)
                                                     .ThenInclude(ss => ss.Speaker)
                                                   .Where(s =>
                                                       s.Title.Contains(query) ||
                                                       s.Track.Name.Contains(query)
                                                   )
                                                   .ToListAsync();

            var speakerResults = await _db.Speakers.Include(s => s.SessionSpeakers)
                                                     .ThenInclude(ss => ss.Session)
                                                   .Where(s =>
                                                       s.Name.Contains(query) ||
                                                       s.Bio.Contains(query) ||
                                                       s.WebSite.Contains(query)
                                                   )
                                                   .ToListAsync();

            var results = sessionResults.Select(s => new SearchResult
            {
                Type = SearchResultType.Session,
                Session = new SessionResponse
                {
                    Id = s.Id,
                    Title = s.Title,
                    Abstract = s.Abstract,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    TrackId = s.TrackId,
                    Track = new ConferenceDTO.Track
                    {
                        Id = s?.TrackId ?? 0,
                        Name = s.Track?.Name
                    },
                    Speakers = s?.SessionSpeakers
                                 .Select(ss => new ConferenceDTO.Speaker
                                 {
                                     Id = ss.SpeakerId,
                                     Name = ss.Speaker.Name
                                 })
                                 .ToList()
                }
            })
            .Concat(speakerResults.Select(s => new SearchResult
            {
                Type = SearchResultType.Speaker,
                Speaker = new SpeakerResponse
                {
                    Id = s.Id,
                    Name = s.Name,
                    Bio = s.Bio,
                    WebSite = s.WebSite,
                    Sessions = s.SessionSpeakers?
                                .Select(ss =>
                                    new ConferenceDTO.Session
                                    {
                                        Id = ss.SessionId,
                                        Title = ss.Session.Title
                                    })
                                .ToList()
                }
            }));

            return results.ToList();
        }
    }
}