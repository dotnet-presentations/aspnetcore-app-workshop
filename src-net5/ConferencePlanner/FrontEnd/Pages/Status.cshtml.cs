using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace FrontEnd.Pages
{
    public class StatusModel : PageModel
    {
        public new int StatusCode { get; set; }

        public string StatusCodeMessage { get; set; }

        public void OnGet(int statusCode)
        {
            StatusCode = statusCode;

            switch (statusCode)
            {
                case StatusCodes.Status404NotFound:
                    StatusCodeMessage = "Not Found";
                    break;
            }
        }
    }
}