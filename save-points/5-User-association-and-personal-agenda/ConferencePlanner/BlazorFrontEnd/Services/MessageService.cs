using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFrontEnd.Services
{
    public class MessageService
    {
		private string _message;

		public string Message
		{
			get { return _message; }
			set { _message = value; ShowMessage = true; }
		}

		public bool ShowMessage { get; set; }
    }
}
