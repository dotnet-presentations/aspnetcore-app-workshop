using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BackEnd.Data;
using Swashbuckle.AspNetCore.Swagger;

namespace BackEnd
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
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                }
                else
                {
                    options.UseSqlite("Data Source=conferences.db");
                }
            });

            services.AddMvcCore()
                .AddJsonFormatters()
                .AddApiExplorer();

            services.AddSwaggerGen(options =>
                options.SwaggerDoc("v1", new Info { Title = "Conference Planner API", Version = "v1" })
            );
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
                app.UseExceptionHandler("/error");
            }

            app.UseSwagger();

            app.UseSwaggerUI(options =>
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Conference Planner API v1")
            );

            app.UseMvc();

            app.Run(context =>
            {
                context.Response.Redirect("/swagger");
                return Task.CompletedTask;
            });

            // TODO: Make this like, good, and only in Dev
            //using (var scope = app.ApplicationServices.CreateScope())
            //{
            //    var db = scope.ServiceProvider.GetService<ApplicationDbContext>();

            //    db.Database.EnsureDeleted();
            //    db.Database.EnsureCreated();

            //    var conference = new Conference { Name = "NDC Oslo 2017" };
            //    db.Conferences.Add(conference);

            //    var startTime = new DateTimeOffset(2017, 6, 14, 9, 0, 0, TimeSpan.FromHours(1));
            //    db.Sessions.Add(new Session
            //    {
            //        Conference = conference,
            //        Title = "Keynote",
            //        StartTime = startTime,
            //        EndTime = startTime + TimeSpan.FromHours(1)
            //    });
            //    startTime = startTime + TimeSpan.FromHours(1) + TimeSpan.FromMinutes(20);
            //    db.Sessions.Add(new Session
            //    {
            //        Conference = conference,
            //        Title = "Thinking in Events",
            //        StartTime = startTime,
            //        EndTime = startTime + TimeSpan.FromHours(1)
            //    });
            //    startTime = startTime + TimeSpan.FromHours(1) + TimeSpan.FromMinutes(20);
            //    db.Sessions.Add(new Session
            //    {
            //        Conference = conference,
            //        Title = "Becoming the Bottleneck",
            //        StartTime = startTime,
            //        EndTime = startTime + TimeSpan.FromHours(1)
            //    });
            //    startTime = startTime + TimeSpan.FromHours(2);
            //    db.Sessions.Add(new Session
            //    {
            //        Conference = conference,
            //        Title = "Functional Techniques for C#",
            //        StartTime = startTime,
            //        EndTime = startTime + TimeSpan.FromHours(1)
            //    });
            //    startTime = startTime + TimeSpan.FromHours(1) + TimeSpan.FromMinutes(20);
            //    db.Sessions.Add(new Session
            //    {
            //        Conference = conference,
            //        Title = "Microservices",
            //        StartTime = startTime,
            //        EndTime = startTime + TimeSpan.FromHours(1)
            //    });
            //    db.SaveChanges();
            //}
        }
    }
}
