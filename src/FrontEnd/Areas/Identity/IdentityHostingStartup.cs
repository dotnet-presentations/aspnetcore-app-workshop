using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FrontEnd.Data;

[assembly: HostingStartup(typeof(FrontEnd.Areas.Identity.IdentityHostingStartup))]
namespace FrontEnd.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<IdentityDbContext>(options =>
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        options.UseSqlServer(
                            context.Configuration.GetConnectionString("IdentityDbContextConnection"));
                    }
                    else
                    {
                        options.UseSqlite("Data Source=identity.db");
                    }
                });

                services.AddDefaultIdentity<User>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 1;
                    options.Password.RequiredUniqueChars = 0;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddClaimsPrincipalFactory<ClaimsPrincipalFactory>();
            });
        }
    }
}