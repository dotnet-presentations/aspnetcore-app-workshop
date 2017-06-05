using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConferenceDTO
{
    public class Conference
    {
        public int ConferenceID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }

        public virtual ICollection<Attendee> Attendees { get; set; }
    }
}
