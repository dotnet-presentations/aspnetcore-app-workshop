using System;
using System.Net.Http;
using System.Threading.Tasks;
using FrontEnd.Services;
using IdentityModel.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FrontEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<RequireLoginFilter>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireAuthenticatedUser()
                          .RequireClaim("IsAdmin", "true");
                });
            });

            var token = GetAccessToken().Result;

            services.AddHttpClient<IApiClient, ApiClient>(client =>
            {
                client.BaseAddress = new Uri(Configuration["serviceUrl"]);
                client.SetBearerToken(token);
            });

            services.AddMvc(options =>
            {
                options.Filters.AddService<RequireLoginFilter>();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler("/Error");
            }

            app.UseStatusCodePagesWithReExecute("/Status/{0}");

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private async Task<string> GetAccessToken()
        {
            using (var client = new HttpClient())
            {
                var url = Configuration["IdentityProvider:Url"];
                var clientId = Configuration["IdentityProvider:ClientId"];
                var clientSecret = Configuration["IdentityProvider:ClientSecret"];

                var disco = await client.GetDiscoveryDocumentAsync(url);
                if (disco.IsError)
                {
                    throw new InvalidOperationException(disco.Error);
                }

                // request token
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Scope = "api"
                });

                if (tokenResponse.IsError)
                {
                    throw new InvalidOperationException(tokenResponse.Error);
                }

                return tokenResponse.AccessToken;
            }
        }
    }
}
