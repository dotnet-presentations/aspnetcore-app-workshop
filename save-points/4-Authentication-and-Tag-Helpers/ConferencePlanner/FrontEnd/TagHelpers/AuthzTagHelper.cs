using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FrontEnd.TagHelpers
{
    [HtmlTargetElement("*", Attributes ="authz")]
    [HtmlTargetElement("*", Attributes = "authz-policy")]
    public class AuthzTagHelper : TagHelper
    {
        private readonly IAuthorizationService _authzService;

        public AuthzTagHelper(IAuthorizationService authzService)
        {
            _authzService = authzService;
        }

        [HtmlAttributeName("authz")]
        public bool RequiresAuthentication { get; set; }

        [HtmlAttributeName("authz-policy")]
        public string RequiredPolicy { get; set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var requiresAuth = RequiresAuthentication || !string.IsNullOrEmpty(RequiredPolicy);
            var showOutput = false;

            if (context.AllAttributes["authz"] != null && !requiresAuth && !ViewContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // authz="false" & user isn't authenticated
                showOutput = true;
            }
            else if (requiresAuth && ViewContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // auth="true" & user is authenticated
                showOutput = true;
            }
            else if (!string.IsNullOrEmpty(RequiredPolicy))
            {
                // auth-policy="foo" & user is authorized for policy "foo"
                var authorized = false;
                var cachedResult = ViewContext.ViewData["AuthPolicy." + RequiredPolicy];
                if (cachedResult != null)
                {
                    authorized = (bool)cachedResult;
                }
                else
                {
                    authorized = await _authzService.AuthorizeAsync(ViewContext.HttpContext.User, RequiredPolicy);
                    ViewContext.ViewData["AuthPolicy." + RequiredPolicy] = authorized;
                }

                showOutput = authorized;
            }

            if (!showOutput)
            {
                output.SuppressOutput();
            }
        }
    }
}
