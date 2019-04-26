using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Data
{
    public class User : IdentityUser
    {
        public bool IsAdmin { get; set; }
    }
}
