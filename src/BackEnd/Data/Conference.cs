using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackEnd.Data
{
    public class Conference
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }

        public virtual ICollection<Speaker> Speakers { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }

        public virtual ICollection<ConferenceAttendee> ConferenceAttendees { get; set; }
    }
}
