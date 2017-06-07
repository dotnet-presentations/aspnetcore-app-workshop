using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Data
{
    public class Speaker
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(4000)]
        public string Bio { get; set; }

        [DataType(DataType.Url)]
        [StringLength(1000)]
        public string WebSite { get; set; }

        public virtual ICollection<SessionSpeaker> SessionSpeakers { get; set; }
    }
}
