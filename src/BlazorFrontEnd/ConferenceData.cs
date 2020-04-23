using ConferenceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFrontEnd
{
    public class ConferenceData : Dictionary<int, IEnumerable<IGrouping<DateTimeOffset?, SessionResponse>>>
    {
        public ConferenceData(int capacity) : base(capacity)
        {
        }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public IEnumerable<(int Offset, DayOfWeek? DayofWeek)> DayOffsets { get; set; }

        public static ConferenceData GenerateConferenceData(List<SessionResponse> sessions)
        {
            var startDate = sessions.Min(s => s.StartTime?.Date);

            var dayOffsets = sessions.Select(s => s.StartTime?.Date)
                                     .Distinct()
                                     .OrderBy(d => d)
                                     .Select(day => (Offset: (int)Math.Floor((day.Value - startDate)?.TotalDays ?? 0),
                                                     day?.DayOfWeek))
                                     .ToList();

            var confData = new ConferenceData(dayOffsets.Count);

            foreach (var day in dayOffsets)
            {
                var filterDate = startDate?.AddDays(day.Offset);

                confData[day.Offset] = sessions.Where(s => s.StartTime?.Date == filterDate)
                                               .OrderBy(s => s.Track.Name)
                                               .GroupBy(s => s.StartTime)
                                               .OrderBy(g => g.Key);
            }

            confData.StartDate = startDate;
            confData.DayOffsets = dayOffsets;

            return confData;
        }
    }
}
