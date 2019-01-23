using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FrontEnd.Data;
using Microsoft.Extensions.DependencyInjection;

namespace FrontEnd.Services
{
    public class AdminService : IAdminService
    {
        private static readonly object _sync = new object();

        private readonly IdentityDbContext _dbContext;
        private bool _adminExists;

        public AdminService(IServiceProvider serviceProvider)
        {
            _dbContext = serviceProvider.CreateScope()
                .ServiceProvider
                .GetRequiredService<IdentityDbContext>();
        }

        public long CreationKey { get; set; }

        public async Task<bool> AllowAdminUserCreationAsync()
        {
            if (_adminExists)
            {
                return false;
            }
            else if (await _dbContext.Users.AnyAsync(user => user.IsAdmin))
            {
                // There are already admin users so disable admin creation
                _adminExists = true;
                return false;
            }
            else
            {
                // There are no admin users so enable admin creation
                if (CreationKey == 0)
                {
                    lock (_sync)
                    {
                        if (CreationKey == 0)
                        {
                            CreationKey = BitConverter.ToInt64(Guid.NewGuid().ToByteArray(), 7);
                        }
                    }
                }
                return true;
            }
        }
    }
}
