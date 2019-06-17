using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Data
{
    public class Track : ConferenceDTO.Track
    {
        public virtual ICollection<Session> Sessions { get; set; }
    }
}