using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FrontEnd.Data
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public bool IsAdmin { get; set; }
    }
}
