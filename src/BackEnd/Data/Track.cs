using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Data
{
    public class Track
    {
        public int ID { get; set; }

        [Required]
        public int ConferenceID { get; set; }

        [Required]
        public Conference Conference { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}