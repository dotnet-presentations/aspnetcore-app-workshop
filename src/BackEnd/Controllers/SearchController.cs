using System.Linq;
using System.Threading.Tasks;
using BackEnd.Data;
using ConferenceDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SearchController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody]SearchTerm term)
        {
            var query = term.Query;
            var sessionResults = await _db.Sessions.Include(s => s.Track)
                                        .Where(s => 
                                            s.Title.Contains(query) || 
                                            s.Track.Name.Contains(query)
                                         )
                                        .ToListAsync();

            var speakerResults = await _db.Speakers.Where(s => 
                                         s.Name.Contains(query) || 
                                         s.Bio.Contains(query) || 
                                         s.WebSite.Contains(query)
                                        )
                                        .ToListAsync();

            var results = sessionResults.Select(s => new SearchResult
            {
                DisplayName = s.Title,
                Id = s.ID,
                Type = SearchResultType.Session
            })
            .Concat(speakerResults.Select(s => new SearchResult
            {
                DisplayName = s.Name,
                Id = s.ID,
                Type = SearchResultType.Speaker
            }));

            return Ok(results);
        }
    }
}