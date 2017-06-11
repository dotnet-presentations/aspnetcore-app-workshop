using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace FrontEnd
{
    public class AdminMiddleware : IMiddleware
    {
        private readonly IAuthorizationService _authz;
        public AdminMiddleware(IAuthorizationService authz)
        {
            _authz = authz;
        }
        
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Items["IsAdmin"] = await _authz.AuthorizeAsync(context.User, "Admin");

            await next(context);
        }
    }
}