using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferenceDTO
{
    public class Session
    {
        public int SessionID { get; set; }

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

        public virtual ICollection<Speaker> Speakers { get; set; }

        public int TrackId { get; set; }

        public Track Track { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}