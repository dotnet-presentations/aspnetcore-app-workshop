using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Data
{
    public class Session
    {
        public int ID { get; set; }

        [Required]
        public int ConferenceID { get; set; }

        [Required]
        public Conference Conference { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(4000)]
        public string Abstract { get; set; }

        public virtual ICollection<SessionSpeaker> SessionSpeakers { get; set; }

        public int TrackId { get; set; }

        public Track Track { get; set; }

        public virtual ICollection<SessionTag> SessionTags { get; set; }
    }
}