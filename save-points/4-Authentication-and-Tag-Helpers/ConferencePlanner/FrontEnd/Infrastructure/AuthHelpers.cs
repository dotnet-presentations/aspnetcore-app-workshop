using System.Linq;
using FrontEnd.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace FrontEnd.Infrastructure
{
    public static class AuthConstants
    {
        public static readonly string IsAdmin = nameof(IsAdmin);
        public static readonly string IsAttendee = nameof(IsAttendee);
        public static readonly string TrueValue = "true";
    }
}

namespace System.Security.Claims
{
    public static class AuthnHelpers
    {
        public static bool IsAdmin(this ClaimsPrincipal principal) =>
            principal.HasClaim(AuthConstants.IsAdmin, AuthConstants.TrueValue);

        public static void MakeAdmin(this ClaimsPrincipal principal) =>
            principal.Identities.First().MakeAdmin();

        public static void MakeAdmin(this ClaimsIdentity identity) =>
            identity.AddClaim(new Claim(AuthConstants.IsAdmin, AuthConstants.TrueValue));
    }
}

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AuthzHelpers
    {
        public static AuthorizationPolicyBuilder RequireIsAdminClaim(this AuthorizationPolicyBuilder builder) =>
            builder.RequireClaim(AuthConstants.IsAdmin, AuthConstants.TrueValue);
    }
}