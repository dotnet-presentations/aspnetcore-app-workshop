using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet("error")]
        public string Error()
        {
            return "An error occurred";
        }
    }
}
