using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BackEnd.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BackEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                //if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                //{
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                //}
                //else
                //{
                //    options.UseSqlite("Data Source=conferences.db");
                //}
            });

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Conference Planner API", Version = "v1" });
#pragma warning disable CS0618 // Type or member is obsolete
                // Swashbuckle.AspNetCore doesn't support all System.Text.Json fully yet so we still need to call this
                options.DescribeAllEnumsAsStrings();
#pragma warning restore CS0618 // Type or member is obsolete
            });

            services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            //app.UseHttpsRedirection();


            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Conference Planner API v1")
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            app.Run(context =>
            {
                context.Response.Redirect("/swagger");
                return Task.CompletedTask;
            });

            //using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            //{
            //    using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
            //    {
            //        var loader = new SessionizeLoader();
            //        //loader.LoadDataAsync(null, context);

            //        context.Database.Migrate();
            //    }
            //}

        }
    }
}
