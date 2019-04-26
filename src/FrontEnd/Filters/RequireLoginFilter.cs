using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FrontEnd.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;

namespace FrontEnd
{
    public class RequireLoginFilter : IAsyncResourceFilter
    {
        private readonly IUrlHelperFactory _urlHelperFactory;

        public RequireLoginFilter(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(context);

            // If the user is authenticated but not a known attendee *and* we've not marked this page
            // to skip attendee welcome, then redirect to the Welcome page
            if (context.HttpContext.User.Identity.IsAuthenticated &&
                !context.Filters.OfType<SkipWelcomeAttribute>().Any())
            {
                var isAttendee = context.HttpContext.User.IsAttendee();

                if (!isAttendee)
                {
                    // No attendee registerd for this user
                    context.HttpContext.Response.Redirect(urlHelper.Page("/Welcome"));

                    return;
                }
            }

            await next();
        }
    }
}