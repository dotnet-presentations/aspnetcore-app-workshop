using System;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace FrontEnd
{
    public class RequireLoginFilter : IAsyncResourceFilter
    {
        private IApiClient _apiClient;
        private IUrlHelperFactory _urlHelperFactory;

        public RequireLoginFilter(IApiClient apiClient, IUrlHelperFactory urlHelperFactory)
        {
            _apiClient = apiClient;
            _urlHelperFactory = urlHelperFactory;
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(context);

            var ignoreRoutes = new[] {
                urlHelper.Page("/Login"),
                urlHelper.Action("logout", "account"),
                urlHelper.Page("/Welcome")
            };

            // If the user is already associated then redirect
            if (context.HttpContext.User.Identity.IsAuthenticated && 
                !ignoreRoutes.Any(path => string.Equals(context.HttpContext.Request.Path, path, StringComparison.OrdinalIgnoreCase)))
            {
                var attendee = await _apiClient.GetAttendeeAsync(context.HttpContext.User.Identity.Name);

                if (attendee == null)
                {
                    context.HttpContext.Response.Redirect(urlHelper.Page("/Welcome"));

                    return;
                }
            }

            await next();
        }
    }
}