using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Pages.Models
{
    public class Session : ConferenceDTO.Session
    {
        [DataType(DataType.MultilineText)]
        public override string Abstract { get => base.Abstract; set => base.Abstract = value; }
    }
}
