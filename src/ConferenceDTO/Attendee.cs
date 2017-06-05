using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferenceDTO
{
    public class Attendee
    {
        public int AttendeeID { get; set; }

        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(200)]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(256)]
        public string EmailAddress { get; set; }

        public virtual ICollection<Conference> Conferences { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}