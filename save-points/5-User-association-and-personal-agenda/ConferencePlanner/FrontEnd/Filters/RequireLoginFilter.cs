using FrontEnd.Filters;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Linq;
using System.Threading.Tasks;

public class RequireLoginFilter : IAsyncResourceFilter
{
    private readonly IApiClient _apiClient;
    private readonly IUrlHelperFactory _urlHelperFactory;

    public RequireLoginFilter(IApiClient apiClient, IUrlHelperFactory urlHelperFactory)
    {
        _apiClient = apiClient;
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
            var attendee = await _apiClient.GetAttendeeAsync(context.HttpContext.User.Identity.Name);

            if (attendee == null)
            {
                // No attendee registerd for this user
                context.HttpContext.Response.Redirect(urlHelper.Page("/Welcome"));

                return;
            }
        }

        await next();
    }
}