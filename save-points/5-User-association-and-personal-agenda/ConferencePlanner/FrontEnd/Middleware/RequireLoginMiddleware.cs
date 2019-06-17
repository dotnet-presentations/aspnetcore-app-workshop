using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FrontEnd.Middleware
{
    public class RequireLoginMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly LinkGenerator _linkGenerator;

        public RequireLoginMiddleware(RequestDelegate next, LinkGenerator linkGenerator)
        {
            _next = next;
            _linkGenerator = linkGenerator;
        }

        public Task Invoke(HttpContext context)
        {
            var endpoint = context.GetEndpoint();

            // If the user is authenticated but not a known attendee *and* we've not marked this page
            // to skip attendee welcome, then redirect to the Welcome page
            if (context.User.Identity.IsAuthenticated &&
                endpoint?.Metadata.GetMetadata<SkipWelcomeAttribute>() == null)
            {
                var isAttendee = context.User.IsAttendee();

                if (!isAttendee)
                {
                    var url = _linkGenerator.GetUriByPage(context, page: "/Welcome");
                    // No attendee registerd for this user
                    context.Response.Redirect(url);

                    return Task.CompletedTask;
                }
            }

            return _next(context);
        }
    }
}
