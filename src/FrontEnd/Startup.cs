﻿using System;
using System.Security.Claims;
using FrontEnd.Data;
using FrontEnd.HealthChecks;
using FrontEnd.Services;
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
                          .RequireIsAdminClaim();
                });
            });

            services.AddHttpClient<IApiClient, ApiClient>(client =>
            {
                client.BaseAddress = new Uri(Configuration["serviceUrl"]);
            });

            services.AddMvc(options =>
            {
                options.Filters.AddService<RequireLoginFilter>();
            })
            .AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeFolder("/Admin", "Admin");
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddHealthChecks()
                    .AddCheck<BackendHealthCheck>("backend")
                    .AddDbContextCheck<IdentityDbContext>();

            services.AddSingleton<IAdminService, AdminService>();
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/Status/{0}");

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseHealthChecks("/health");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
