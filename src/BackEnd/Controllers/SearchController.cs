using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Data;
using ConferenceDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace BackEnd
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public SearchController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost]
        public async Task<ActionResult<List<SearchResult>>> Search(SearchTerm term)
        {
            using var dbContext1 = _serviceProvider.GetRequiredService<ApplicationDbContext>();
            using var dbContext2 = _serviceProvider.GetRequiredService<ApplicationDbContext>();

            var query = term.Query;
            var sessionResultsTask = dbContext1.Sessions.Include(s => s.Track)
                                                   .Include(s => s.SessionSpeakers)
                                                     .ThenInclude(ss => ss.Speaker)
                                                   .Where(s =>
                                                       s.Title.Contains(query) ||
                                                       s.Track.Name.Contains(query)
                                                   )
                                                   .ToListAsync();

            var speakerResultsTask = dbContext2.Speakers.Include(s => s.SessionSpeakers)
                                                     .ThenInclude(ss => ss.Session)
                                                   .Where(s =>
                                                       s.Name.Contains(query) ||
                                                       s.Bio.Contains(query) ||
                                                       s.WebSite.Contains(query)
                                                   )
                                                   .ToListAsync();

            var sessionResults = await sessionResultsTask;
            var speakerResults = await speakerResultsTask;

            var results = sessionResults.Select(s => new SearchResult
            {
                Type = SearchResultType.Session,
                Value = JObject.FromObject(new SessionResponse
                {
                    ID = s.ID,
                    Title = s.Title,
                    Abstract = s.Abstract,
                    ConferenceID = s.ConferenceID,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    TrackId = s.TrackId,
                    Track = new ConferenceDTO.Track
                    {
                        TrackID = s?.TrackId ?? 0,
                        Name = s.Track?.Name
                    },
                    Speakers = s?.SessionSpeakers
                                 .Select(ss => new ConferenceDTO.Speaker
                                 {
                                     ID = ss.SpeakerId,
                                     Name = ss.Speaker.Name
                                 })
                                 .ToList()
                })
            })
            .Concat(speakerResults.Select(s => new SearchResult
            {
                Type = SearchResultType.Speaker,
                Value = JObject.FromObject(new SpeakerResponse
                {
                    ID = s.ID,
                    Name = s.Name,
                    Bio = s.Bio,
                    WebSite = s.WebSite,
                    Sessions = s.SessionSpeakers?
                                .Select(ss =>
                                    new ConferenceDTO.Session
                                    {
                                        ID = ss.SessionId,
                                        Title = ss.Session.Title
                                    })
                                .ToList()
                })
            }));

            return results.ToList();
        }
    }
}
